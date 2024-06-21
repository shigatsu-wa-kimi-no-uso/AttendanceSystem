#ifndef LOGGER_H_
#define LOGGER_H_
#pragma once
#include "global.h"

namespace Logger {

#undef ERROR
	enum class LOGTYPE
	{
		DEBUG, INFO, WARNING, ERROR, ENUMCOUNT
	};

	constexpr LOGTYPE DEBUG = LOGTYPE::DEBUG;
	constexpr LOGTYPE INFO = LOGTYPE::INFO;
	constexpr LOGTYPE WARNING = LOGTYPE::WARNING;
	constexpr LOGTYPE ERROR = LOGTYPE::ERROR;

	//������־ϵͳ(����������ɾ�������define���)
#define LOGGER_ON

//������־�ȼ�
#define LOGLEVEL DEBUG

	//��־ϵͳ��ʼ��(���ļ���)
	void logger_init();

	//��־ϵͳ�˳�����, ������־����β����(��ر��ļ���), Ӧ���ڳ����˳�ǰ����
	void logger_exit();

	//��־ϵͳ���ؼ��
	//����Ϊ��Ե���־ϵͳ��ʱ(LOGGER_ON������ʱ)��һЩԤ�����߼�
#ifdef LOGGER_ON
	//�����־�ȼ��Ƿ��Ѿ�ָ��

#ifndef LOGLEVEL
#error LOGLEVEL undefined.
#endif // LOGLEVEL


//��ȡ��ǰʱ��ĺ���
	static char* getTimeString(time_t timestamp);

	//��ӡ��־�ĺ���
	void printLog(LOGTYPE type, const char* format, ...);


#define info(format,...) Logger::printLog(Logger::LOGTYPE::INFO,"%-60s| "##format,__FUNCTION__,__VA_ARGS__)
#define error(format,...) Logger::printLog(Logger::LOGTYPE::ERROR,"%-60s| "##format,__FUNCTION__,__VA_ARGS__)
#define warning(format,...) Logger::printLog(Logger::LOGTYPE::WARNING,"%-60s| "##format,__FUNCTION__,__VA_ARGS__)
#define debug(format,...) Logger::printLog(Logger::LOGTYPE::DEBUG,"%-60s| "##format,__FUNCTION__,__VA_ARGS__)
#define trace Logger::printLog(Logger::LOGTYPE::DEBUG, "\nIn file %s\nLine: %d\nFunction:%s\n", __FILE__, __LINE__, __FUNCTION__)
#else // LOGGER_ON
//��־ϵͳ�ر�ʱ, ��������ĺ�Ϊ((void)0), ���йش�ӡ��־�Ĵ����Ϊ�մ���, ��ֹӰ��������, ������ֱ�Ӳ�������صĴ�ӡ��־��
#define info(format,...) ((void)0)
#define error(format,...) ((void)0)
#define warning(format,...) ((void)0)
#define debug(format,...) ((void)0)
#define trace ((void)0)

#endif // LOGGER_ON
}
#endif // !LOGGER_H_