#include "DataAccessor.h"
#include <Global/logger.h>

DataAccessor::DataAccessor(shared_ptr<SerialPort> port) :port(port) {
	
}

ResultCode DataAccessor::sendRequest(ReqHeader* header, ReqBody* body) {
	assert(header != nullptr && body != nullptr);
	size_t bodyLen = header->bLength - sizeof(ReqHeader) - 1;  //��ȥ��1��У�����ռ��1byte
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
	BYTE length = port->GetBytesInCOM(); //��ȡ���ڻ��������ֽ���
	assert(length < RECV_BUFSIZE);
	BYTE readbytes, inbyte;
	// �����Ŷ��������ص����ݰ����ȣ����ݰ�������8�ֽ�,��������˵���������쳣
	if (length >= 8) {
		readbytes = 0;
		// ��ȡ���ڻ���������
		do {
			inbyte = 0;
			if (port->ReadChar(inbyte) == true)
			{
				recvBuffer[readbytes] = inbyte;
				readbytes++;
			}
		} while (--length);
		//����˭����˭�ͷ�ԭ��,DataAccessor������Ϊheader�����ڴ�
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
		error("�����ų�ʱ����������������������Ƿ�������");
		//��ջ�����
		while (length > 0) {
			port->ReadChar(inbyte);
		}
		return ResultCode::TIMEOUT;
	}
}