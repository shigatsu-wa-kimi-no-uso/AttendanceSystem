#include "ReaderService.h"

ReaderService::ReaderService(shared_ptr<DataAccessor> accessor) :accessor(accessor){

}

ReaderService::ReaderService(shared_ptr<SerialPort> port):accessor(make_shared<DataAccessor>(port)) {

}

ResultCode ReaderService::readCardId(RespHeader& respHeader, ReadCardIdResp& respBody) {
	ReqHeader reqHeader;
	ReadCardIdReq reqBody;
	ResultCode result;
	reqHeader.bType = RT_BASIC;
	reqHeader.bLength = 0x08;
	reqHeader.bCmd = CMD_READ_CARD_ID;
	reqHeader.bAddr = 0x20;
	reqBody.bPrompt = 0x01;

	if ((result = accessor->sendRequest(&reqHeader, &reqBody)) == ResultCode::SUCCESS) {
		Sleep(200);
		result = accessor->readResponse(&respHeader, &respBody);
	} 
	return result;
}

ResultCode ReaderService::writeBlockData(WriteBlockReq& reqBody, RespHeader& respHeader) {
	ReqHeader reqHeader;
	NullResp respBody;
	ResultCode result;

	reqHeader.bType = RT_BASIC;
	reqHeader.bLength = 0x17;
	reqHeader.bCmd = CMD_WRITE_BLOCK;
	reqHeader.bAddr = 0x20;
	if ((result = accessor->sendRequest(&reqHeader, &reqBody)) == ResultCode::SUCCESS) {
		Sleep(200);
		result = accessor->readResponse(&respHeader, &respBody);
	}
	return result;
}

ResultCode ReaderService::readBlockData(ReadBlockReq& reqBody, RespHeader& respHeader, ReadBlockResp& respBody){
	ReqHeader reqHeader;
	ResultCode result;
	reqHeader.bType = RT_BASIC;
	reqHeader.bLength = 0x17;
	reqHeader.bCmd = CMD_READ_BLOCK;
	reqHeader.bAddr = 0x20;
	if ((result = accessor->sendRequest(&reqHeader, &reqBody)) == ResultCode::SUCCESS) {
		Sleep(200);
		result = accessor->readResponse(&respHeader, &respBody);
	}
	return result;
}
