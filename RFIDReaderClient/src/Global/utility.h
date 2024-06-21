#ifndef UTILITY_H_
#define UTILITY_H_
#pragma once
#include <Global/global.h>
#include <iostream>

void CheckSumOut(UCHAR* buf, UCHAR len);

bool CheckSumIn(UCHAR* buf, UCHAR len);

//�ֽ���ת��Ϊʮ�������ַ�������һ��ʵ�ַ�ʽ  
void Hex2Str(const UCHAR* sSrc, UCHAR* sDest, int nSrcLen);

ostream& operator<<(ostream& os, const ResultCode& code);

#endif // !UTILITY_H_