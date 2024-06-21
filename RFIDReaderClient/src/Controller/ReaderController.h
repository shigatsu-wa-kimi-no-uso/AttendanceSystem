#ifndef READER_CONTROLLER_H_
#define READER_CONTROLLER_H_
#include <Global/global.h>
#include <Service/ReaderService.h>
#include <Driver/SerialPort.h>
#pragma once

class ReaderController
{
	shared_ptr<ReaderService> rs;
public:
	ReaderController(shared_ptr<ReaderService> rs);

	ReaderController(shared_ptr<SerialPort> port);

	ResultCode readCardInfo(CardInfo& pCardInfo);

	ResultCode writeUserInfo(const UserInfo& info);

	ResultCode readUserInfo(UserInfo& info);

	ResultCode writeMonthlyRecord(const MonthlyRecord& monthlyRecord);

	ResultCode readMonthlyRecord(MonthlyRecord& monthlyRecord);

};


#endif // !READER_CONTROLLER_H_
