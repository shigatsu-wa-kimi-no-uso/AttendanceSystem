#ifndef DATA_ACCESSOR_H_
#define DATA_ACCESSOR_H_
#pragma once
#include <Global/global.h>
#include <Global/utility.h>
#include <Driver/SerialPort.h>

class DataAccessor
{
#define SEND_BUFSIZE 32
#define RECV_BUFSIZE 32
	shared_ptr<SerialPort> port;
	BYTE sendBuffer[SEND_BUFSIZE];
	BYTE recvBuffer[RECV_BUFSIZE];
public:
	DataAccessor(shared_ptr<SerialPort> port);
	ResultCode sendRequest(ReqHeader* header, ReqBody* body);
	ResultCode readResponse(RespHeader* header, RespBody* body);
};

#endif // !DATA_ACCESSOR_H_
