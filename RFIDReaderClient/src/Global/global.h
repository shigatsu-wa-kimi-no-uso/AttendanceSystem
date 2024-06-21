#define _CRT_SECURE_NO_WARNINGS
#ifndef GLOBAL_H_
#define GLOBAL_H_
#pragma once
#define WIN32_LEAN_AND_MEAN             // 从 Windows 头文件中排除极少使用的内容
#include <windows.h>
#include <memory>
#include <assert.h>
#include <string>
using std::string;
using std::ostream;
using std::shared_ptr;
using std::make_shared;
using std::weak_ptr;
using ReqBody = void;
using RespBody = void;
using QWORD = unsigned long long;

#ifdef DLL_EXPORTS
#define DLL _declspec(dllexport) __stdcall
#else
#define DLL _declspec(dllimport)
#endif

enum class ResultCode {
	SUCCESS = 0x00,
	FAIL = 0x01,
	NO_CARD = 0x02,
	BAD_TRANSMISSION = 0x03,
	OPENPORT_FAILED = 0x04,
	TIMEOUT = 0x05,
};

enum ReqType : BYTE{
	RT_BASIC = 0x01,  //卡片相关操作命令（读卡号，读数据块，写数据块等操作）
	RT_READER_PARAM_QUERY, //读写器参数查询
	RT_READER_PARAM_SET, //读写器参数设置
	RT_OTHER  // 其他命令
};

enum ReqCmdBasic : BYTE {
	CMD_READ_CARD_ID = 0xA1,
	CMD_RESERVED1,
	CMD_READ_BLOCK,
	CMD_WRITE_BLOCK,
	CMD_ENCRYPT_SECTOR,
	CMD_INIT_WALLET,
	CMD_WALLET_DECR,
	CMD_WALLET_INCR,
	CMD_WALLET_QUERY
};

enum RespStatus : BYTE {
	SUCCESS = 0x00,
	FAIL = 0x01
};

#pragma pack(1)
struct ReqHeader {
	BYTE bType;
	BYTE bLength;
	BYTE bCmd;
	BYTE bAddr;
};

struct RespHeader {
	BYTE bType;
	BYTE bLength;
	BYTE bCmd;
	BYTE bAddr;
	BYTE bStatus;
};

struct ReadCardIdReq {
	BYTE bReserved1 = 0x00;
	BYTE bPrompt;
	BYTE bReserved2 = 0x00;
};

struct ReadCardIdResp {
	WORD wCardType;
	DWORD dwCardId;
};

struct ReadBlockReq {
	BYTE bBlockId;
	BYTE bPrompt;
	BYTE bReserved = 0x00;
};

struct ReadBlockResp {
	BYTE bData[16];
};

struct WriteBlockReq {
	BYTE bBlockId;
	BYTE bPrompt;
	BYTE bData[16];
};

struct NullResp {
	WORD wReserved = 0x0000;
};

#pragma pack()

struct UserInfo {
	UINT userId;
	UINT cardId;
	char name[16];
	int role;
};

struct UserInfoW {
	UINT userId;
	UINT cardId;
	wchar_t name[8];
	int role;
};

struct CardInfo {
	UINT cardType;
	UINT cardId;
};

union DailyRecord {
	struct{
		BYTE hours : 5;
		BYTE minutes : 3;
	};
	BYTE value;
};


struct MonthlyRecord {
	BYTE workingTimes1[16];
	BYTE workingTimes2[16];
	QWORD lastUpdateTimestamp;
};



#endif // !GLOBAL_H_
