#include "dllexports.h"
#include <Global/logger.h>
#include <Controller/ReaderController.h>

shared_ptr<SerialPort> port;
shared_ptr<ReaderController> rc;

int RC_initialize(UINT portNo) {
	shared_ptr<SerialPort> port = make_shared<SerialPort>();
	if (!port->InitPort(portNo)) {
		//error("��ʼ��COM3ʧ�ܣ������д���˿��Ƿ�ΪCOM3�������Ƿ����������ռ�ã�");
		return (int)ResultCode::OPENPORT_FAILED;
	}
	rc = make_shared<ReaderController>(port);
	return (int)ResultCode::SUCCESS;
}

int RC_readCardInfo(CardInfo* pCardInfo) {
	return (int)rc->readCardInfo(*pCardInfo);
}


//pUserInfo->nameΪ�ַ���ָ��,�����߸������ռ䣡
int RC_readUserInfo(UserInfo* pUserInfo){
	return (int)rc->readUserInfo(*pUserInfo);
}

int RC_readUserInfoW(UserInfoW* pUserInfoW) {
	return (int)rc->readUserInfo(*((UserInfo*)pUserInfoW));
}


int RC_writeUserInfo(UserInfo* pUserInfo) {
	return (int)rc->writeUserInfo(*pUserInfo);
}


int RC_close(){
	rc.~shared_ptr();
	port.~shared_ptr();
	return  (int)ResultCode::SUCCESS;
}

int RC_writeMonthlyRecord(MonthlyRecord* pMonthlyRecord) {
	return (int)rc->writeMonthlyRecord(*pMonthlyRecord);
}

int RC_readMonthlyRecord(MonthlyRecord* pMonthlyRecord){
	return (int)rc->readMonthlyRecord(*pMonthlyRecord);
}
