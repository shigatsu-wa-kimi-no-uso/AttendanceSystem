#include "ReaderController.h"

ReaderController::ReaderController(shared_ptr<ReaderService> rs):rs(rs){

}

ReaderController::ReaderController(shared_ptr<SerialPort> port):rs(make_shared<ReaderService>(port)){
}

ResultCode ReaderController::readCardInfo(CardInfo& cardInfo) {
	RespHeader respHeader;
	ReadCardIdResp respBody;
	ResultCode code = rs->readCardId(respHeader, respBody);
	if (code == ResultCode::SUCCESS) {
		cardInfo.cardId = respBody.dwCardId;
		cardInfo.cardType = respBody.wCardType;
	}
	return code;
}

ResultCode ReaderController::writeUserInfo(const UserInfo& info) {
	RespHeader respHeader;
	WriteBlockReq reqBody1, reqBody2;
	reqBody1.bBlockId = 56;
	reqBody1.bPrompt = 0;
	memcpy(reqBody1.bData, info.name, sizeof(info.name));
	reqBody2.bBlockId = 57;
	reqBody2.bPrompt = 0;
	memcpy(reqBody2.bData, &info.userId, sizeof(info.userId));
	memcpy(reqBody2.bData + sizeof(info.userId), &info.role, sizeof(info.role));
	ResultCode code = rs->writeBlockData(reqBody1, respHeader);
	if (code == ResultCode::SUCCESS) {
		code = rs->writeBlockData(reqBody2, respHeader);
	}
	return code;
}

ResultCode ReaderController::readUserInfo(UserInfo& info) {
	RespHeader respHeader;
	ReadBlockResp respBody1, respBody2;
	ReadBlockReq reqBody1, reqBody2;
	CardInfo cardInfo;
	assert(info.name != nullptr);
	ResultCode code = readCardInfo(cardInfo);
	if (code == ResultCode::SUCCESS) {
		reqBody1.bBlockId = 56;
		reqBody1.bPrompt = 0;
		reqBody2.bBlockId = 57;
		reqBody2.bPrompt = 0;
		code = rs->readBlockData(reqBody1, respHeader, respBody1);
		if (code == ResultCode::SUCCESS) {
			code = rs->readBlockData(reqBody2, respHeader, respBody2);
			if (code == ResultCode::SUCCESS) {
				memcpy(info.name, respBody1.bData, sizeof(respBody1.bData)); //不负责为info.name分配空间
				memcpy(&info.userId, respBody2.bData, sizeof(info.userId));
				memcpy(&info.role, respBody2.bData + sizeof(info.userId), sizeof(info.role));
				info.cardId = cardInfo.cardId;
			}
		}
	}
	return code;
}

ResultCode ReaderController::writeMonthlyRecord(const MonthlyRecord& monthlyRecord) {
	RespHeader respHeader;
	WriteBlockReq reqBody1,reqBody2,reqBody3;
	reqBody1.bBlockId = 60;
	reqBody1.bPrompt = 0;
	reqBody2.bBlockId = 61;
	reqBody2.bPrompt = 0;
	reqBody3.bBlockId = 62;
	reqBody3.bPrompt = 0;
	memcpy(reqBody1.bData,&monthlyRecord.workingTimes1, sizeof(monthlyRecord.workingTimes1));
	memcpy(reqBody2.bData, &monthlyRecord.workingTimes2, sizeof(monthlyRecord.workingTimes2));
	memcpy(reqBody3.bData, &monthlyRecord.lastUpdateTimestamp, sizeof(monthlyRecord.lastUpdateTimestamp));
	ResultCode code;
	(code = rs->writeBlockData(reqBody1, respHeader)) == ResultCode::SUCCESS
		&& (code = rs->writeBlockData(reqBody2, respHeader)) == ResultCode::SUCCESS
		&& (code = rs->writeBlockData(reqBody3, respHeader))==ResultCode::SUCCESS;
	return code;
}

ResultCode ReaderController::readMonthlyRecord(MonthlyRecord& monthlyRecord) {
	RespHeader respHeader;
	ReadBlockResp respBody1, respBody2,respBody3;
	ReadBlockReq reqBody1, reqBody2,reqBody3;
	ResultCode code;
	reqBody1.bBlockId = 60;
	reqBody1.bPrompt = 0;
	reqBody2.bBlockId = 61;
	reqBody2.bPrompt = 0;
	reqBody3.bBlockId = 62;
	reqBody3.bPrompt = 0;
	(code = rs->readBlockData(reqBody1, respHeader, respBody1)) == ResultCode::SUCCESS &&
		(code = rs->readBlockData(reqBody2, respHeader, respBody2)) == ResultCode::SUCCESS &&
		(code = rs->readBlockData(reqBody3, respHeader, respBody3)) == ResultCode::SUCCESS;
	if (code == ResultCode::SUCCESS) {
		memcpy(monthlyRecord.workingTimes1, respBody1.bData, sizeof(monthlyRecord.workingTimes1)); //不负责为info.name分配空间
		memcpy(monthlyRecord.workingTimes2, respBody2.bData, sizeof(monthlyRecord.workingTimes2));
		memcpy(&monthlyRecord.lastUpdateTimestamp, respBody3.bData, sizeof(monthlyRecord.lastUpdateTimestamp));
	}

	return code;
}

