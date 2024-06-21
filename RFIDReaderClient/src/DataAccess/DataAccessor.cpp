#include "DataAccessor.h"
#include <Global/logger.h>

DataAccessor::DataAccessor(shared_ptr<SerialPort> port) :port(port) {
	
}

ResultCode DataAccessor::sendRequest(ReqHeader* header, ReqBody* body) {
	assert(header != nullptr && body != nullptr);
	size_t bodyLen = header->bLength - sizeof(ReqHeader) - 1;  //减去的1是校验和所占的1byte
	assert(bodyLen < SEND_BUFSIZE - sizeof(ReqHeader) - 1);
	memcpy(sendBuffer, header, sizeof(ReqHeader));
	memcpy(sendBuffer + sizeof(ReqHeader), body, bodyLen);
	CheckSumOut(sendBuffer, header->bLength);
	if (port->WriteData(sendBuffer, header->bLength)) {
		return ResultCode::SUCCESS;
	} else {
		return ResultCode::FAIL;
	}
}

ResultCode DataAccessor::readResponse(RespHeader* header, RespBody* body) {
	assert(header != nullptr && body != nullptr);
	BYTE length = port->GetBytesInCOM(); //获取串口缓冲区中字节数
	assert(length < RECV_BUFSIZE);
	BYTE readbytes, inbyte;
	// 读卡号读卡器返回的数据包长度：数据包至少是8字节,若无数据说明读卡器异常
	if (length >= 8) {
		readbytes = 0;
		// 获取串口缓冲区数据
		do {
			inbyte = 0;
			if (port->ReadChar(inbyte) == true)
			{
				recvBuffer[readbytes] = inbyte;
				readbytes++;
			}
		} while (--length);
		//根据谁分配谁释放原则,DataAccessor不负责为header分配内存
		memcpy(header, recvBuffer, sizeof(RespHeader));
		bool parityCheckOK = CheckSumIn(recvBuffer, header->bLength);
		if (parityCheckOK) {
			if (header->bStatus == SUCCESS) {
				memcpy(body, recvBuffer + sizeof(RespHeader), header->bLength - sizeof(RespHeader) - 1);
				return ResultCode::SUCCESS;
			} else {
				return ResultCode::NO_CARD;
			}
		} else {
			return ResultCode::BAD_TRANSMISSION;
		}
	} else {
		error("读卡号超时……，请检查读卡器的连接是否正常！");
		//清空缓冲区
		while (length > 0) {
			port->ReadChar(inbyte);
		}
		return ResultCode::TIMEOUT;
	}
}