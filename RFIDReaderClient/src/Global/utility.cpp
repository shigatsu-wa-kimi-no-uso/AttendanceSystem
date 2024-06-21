#include "utility.h"
#include <stdio.h>

//奇校验：将原始数据的二进制数位中1的个数统计出来，如果是奇数就在数据的最后添加一个0，如果是偶数就添加一个1作为校验位。
void CheckSumOut(UCHAR* buf, UCHAR len) 
{
	UCHAR i;
	UCHAR checksum;
	checksum = 0;
	for (i = 0; i < (len - 1); i++) //共len个字节,对前len-1个字节计算校验和
	{
		checksum ^= buf[i];
	}
	buf[len - 1] = (UCHAR)~checksum; //最后一个字节放置校验和
}

bool CheckSumIn(UCHAR* buf, UCHAR len)
{
	UCHAR i;
	UCHAR checksum;
	checksum = 0;
	for (i = 0; i < (len - 1); i++)
	{
		checksum ^= buf[i];
	}
	if (buf[len - 1] == (UCHAR)~checksum)
	{
		return true;
	}
	return false;
}

//字节流转换为十六进制字符串的另一种实现方式  
void Hex2Str(const UCHAR* sSrc, UCHAR* sDest, int nSrcLen)
{
	int  i;
	char szTmp[3];

	for (i = 0; i < nSrcLen; i++)
	{
		sprintf_s(szTmp, "%02X", (unsigned char)sSrc[i]);
		memcpy(&sDest[i * 2], szTmp, 2);
	}
	sDest[nSrcLen * 2] = '\0';
	return;
}

ostream& operator<<(ostream& os, const ResultCode& code){
	string s;
	switch (code) {
	case ResultCode::TIMEOUT:
		s = "读取响应超时，请检查读卡器的连接是否正常！";
		break;
	case ResultCode::SUCCESS:
		s = "操作成功";
		break;
	case ResultCode::FAIL:
		s = "操作失败，请检查IC卡是否放置在读卡器的感应区内！";
		break;
	case ResultCode::NO_CARD:
		s = "没有检测到卡，请检查IC卡是否放置在读卡器的感应区内！";
		break;
	case ResultCode::BAD_TRANSMISSION:
		s = "数据包损坏，请检查数据线是否损坏或将设备放在低干扰环境内！";
	}
	os << s;
	return os;
}