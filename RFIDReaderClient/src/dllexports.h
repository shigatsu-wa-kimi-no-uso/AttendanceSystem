#ifndef DLLEXPORTS_H_
#define DLLEXPORTS_H_
#pragma once
#define DLL_EXPORTS
#include <Global/global.h>

extern "C" {
	int DLL RC_initialize(UINT portNo);

	int DLL RC_readCardInfo(CardInfo* pCardInfo);

	int DLL RC_readUserInfo(UserInfo* pUserInfo);

	int DLL RC_readUserInfoW(UserInfoW* pUserInfoW);

	int DLL RC_writeUserInfo(UserInfo* pUserInfo);

	int DLL RC_writeMonthlyRecord(MonthlyRecord* pMonthlyRecord);

	int DLL RC_readMonthlyRecord(MonthlyRecord* pMonthlyRecord);

	int DLL RC_close();
}


#endif // DLLEXPORTS_H_