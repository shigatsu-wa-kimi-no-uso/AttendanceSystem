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

	//开启日志系统(如果不想打开则删除下面的define语句)
#define LOGGER_ON

//设置日志等级
#define LOGLEVEL DEBUG

	//日志系统初始化(打开文件等)
	void logger_init();

	//日志系统退出函数, 用于日志的收尾工作(如关闭文件等), 应当在程序退出前调用
	void logger_exit();

	//日志系统开关检测
	//下面为针对当日志系统打开时(LOGGER_ON被定义时)的一些预处理逻辑
#ifdef LOGGER_ON
	//检测日志等级是否已经指定

#ifndef LOGLEVEL
#error LOGLEVEL undefined.
#endif // LOGLEVEL


//获取当前时间的函数
	static char* getTimeString(time_t timestamp);

	//打印日志的函数
	void printLog(LOGTYPE type, const char* format, ...);


#define info(format,...) Logger::printLog(Logger::LOGTYPE::INFO,"%-60s| "##format,__FUNCTION__,__VA_ARGS__)
#define error(format,...) Logger::printLog(Logger::LOGTYPE::ERROR,"%-60s| "##format,__FUNCTION__,__VA_ARGS__)
#define warning(format,...) Logger::printLog(Logger::LOGTYPE::WARNING,"%-60s| "##format,__FUNCTION__,__VA_ARGS__)
#define debug(format,...) Logger::printLog(Logger::LOGTYPE::DEBUG,"%-60s| "##format,__FUNCTION__,__VA_ARGS__)
#define trace Logger::printLog(Logger::LOGTYPE::DEBUG, "\nIn file %s\nLine: %d\nFunction:%s\n", __FILE__, __LINE__, __FUNCTION__)
#else // LOGGER_ON
//日志系统关闭时, 定义下面的宏为((void)0), 将有关打印日志的代码变为空代码, 防止影响代码编译, 而不是直接不定义相关的打印日志宏
#define info(format,...) ((void)0)
#define error(format,...) ((void)0)
#define warning(format,...) ((void)0)
#define debug(format,...) ((void)0)
#define trace ((void)0)

#endif // LOGGER_ON
}
#endif // !LOGGER_H_
