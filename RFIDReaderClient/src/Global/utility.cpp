#include "utility.h"
#include <stdio.h>

//��У�飺��ԭʼ���ݵĶ�������λ��1�ĸ���ͳ�Ƴ���������������������ݵ�������һ��0�������ż�������һ��1��ΪУ��λ��
void CheckSumOut(UCHAR* buf, UCHAR len) 
{
	UCHAR i;
	UCHAR checksum;
	checksum = 0;
	for (i = 0; i < (len - 1); i++) //��len���ֽ�,��ǰlen-1���ֽڼ���У���
	{
		checksum ^= buf[i];
	}
	buf[len - 1] = (UCHAR)~checksum; //���һ���ֽڷ���У���
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

//�ֽ���ת��Ϊʮ�������ַ�������һ��ʵ�ַ�ʽ  
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
		s = "��ȡ��Ӧ��ʱ������������������Ƿ�������";
		break;
	case ResultCode::SUCCESS:
		s = "�����ɹ�";
		break;
	case ResultCode::FAIL:
		s = "����ʧ�ܣ�����IC���Ƿ�����ڶ������ĸ�Ӧ���ڣ�";
		break;
	case ResultCode::NO_CARD:
		s = "û�м�⵽��������IC���Ƿ�����ڶ������ĸ�Ӧ���ڣ�";
		break;
	case ResultCode::BAD_TRANSMISSION:
		s = "���ݰ��𻵣������������Ƿ��𻵻��豸���ڵ͸��Ż����ڣ�";
	}
	os << s;
	return os;
}