#ifndef READER_SERVICE_H_
#define READER_SERVICE_H_
#pragma once
#include <DataAccess/DataAccessor.h>

class ReaderService{
	shared_ptr<DataAccessor> accessor;
public:
	ReaderService(shared_ptr<SerialPort> port);
	ReaderService(shared_ptr<DataAccessor> accessor);
	ResultCode readCardId(RespHeader& respHeader, ReadCardIdResp& respBody);
	ResultCode writeBlockData(WriteBlockReq& reqBody, RespHeader& respHeader);
	ResultCode readBlockData(ReadBlockReq& reqBody, RespHeader& respHeader, ReadBlockResp& respBody);
};

#endif // !READER_SERVICE_H_
