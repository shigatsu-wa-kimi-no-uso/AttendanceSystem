using AttendanceSystemUI.Clients;
using AttendanceSystemUI.Entities;
using System.Configuration;
using System.Xml.Linq;

namespace AttendanceSystemUI.Controllers
{
    public class Controller
    {
        Clients.HttpClient httpClient;

        RFIDReaderClient readerClient;

		private readonly string attendanceSystemServerBaseURL = ConfigurationManager.AppSettings["AttendanceSystemServerBaseURL"];

		private readonly string voiceSystemServerBaseURL = ConfigurationManager.AppSettings["VoiceSystemServerBaseURL"];

		private readonly string loginAPIPath = ConfigurationManager.AppSettings["LoginAPIPath"].ToString();

		private readonly string logoutAPIPath = ConfigurationManager.AppSettings["LogoutAPIPath"].ToString();

		private readonly string getAllAttendanceRecordsAPIPath = ConfigurationManager.AppSettings["GetAllAttendanceRecordsAPIPath"].ToString();

		private readonly string getUserAttendanceRecordsAPIPath = ConfigurationManager.AppSettings["GetUserAttendanceRecordsAPIPath"].ToString();

		private readonly string voiceOutAPIPath = ConfigurationManager.AppSettings["VoiceOutAPIPath"].ToString();

		public Controller()
        {
            readerClient = new RFIDReaderClient();
            httpClient = new Clients.HttpClient();
        }
		public Controller(in RFIDReaderClient readerClient,in Clients.HttpClient httpClient) {
			this.readerClient = readerClient;
			this.httpClient = httpClient;
		}

		public ResultStatus userLoginByCard(out UserInfo userInfo, out CheckTime checkTime) {
			ResultStatus resultStatus;
            resultStatus = readerClient.readUserInfo(out userInfo);
			checkTime = null;
			if (resultStatus == ResultStatus.SUCCESS) {
				//读卡成功就向服务器发送消息,记录这次上下班
				string paramStr = String.Format("userId={0}&cardId={1}&name={2}&role={3}", userInfo.userId,userInfo.cardId,userInfo.name,userInfo.role);
				string path = attendanceSystemServerBaseURL + loginAPIPath + '?' + paramStr;
				resultStatus = httpClient.doHttpRequest(path, RestSharp.Method.Post, out ServerAPIResult<CheckTime> response);
				if (resultStatus == ResultStatus.SUCCESS) {
					resultStatus = (ResultStatus)response.code;
					if (response.data != null) {
						checkTime = response.data;
					}
				} else {
					resultStatus = ResultStatus.SERVER_RESPONSE_TIMEOUT;
				}
			}
			return resultStatus;
        }

		public ResultStatus userLogoutByCard(out UserInfo userInfo, out CheckTime checkTime) {
			ResultStatus resultStatus;
			checkTime = null;
			resultStatus = readerClient.readUserInfo(out userInfo);
			if (resultStatus == ResultStatus.SUCCESS) {
				//读卡成功就向服务器发送消息,记录这次上下班
				string paramStr = String.Format("userId={0}&cardId={1}&name={2}&role={3}", userInfo.userId, userInfo.cardId, userInfo.name, userInfo.role);
				string path = attendanceSystemServerBaseURL + logoutAPIPath + '?' + paramStr;
				resultStatus = httpClient.doHttpRequest(path, RestSharp.Method.Post, out ServerAPIResult<CheckTime> response);
				if (resultStatus == ResultStatus.SUCCESS) {
					resultStatus = (ResultStatus)response.code;
					if (response.success && resultStatus == ResultStatus.SUCCESS) {
						checkTime = response.data;
						WorkingTime t = checkTime.workingTimeToday;
						resultStatus = readerClient.readMonthlyRecord(out MonthlyRecord monthlyRecord);	
						if(resultStatus == ResultStatus.SUCCESS) {
							DateTime lastUpdate = monthlyRecord.lastUpdateTimestamp.getDateTime();
							DateTime now = DateTime.Now;
							int day = now.Day;
							int month = now.Month;
							int year = now.Year;
							if(month !=lastUpdate.Month || year!=lastUpdate.Year) {
								monthlyRecord.reset();
							}
							monthlyRecord.setWorkingTime(day, t.hours, t.minutes);
							resultStatus = readerClient.writeMonthlyRecord(ref monthlyRecord);
							return resultStatus;
						}
					}
				} else {
					resultStatus = ResultStatus.SERVER_RESPONSE_TIMEOUT;
				}
			}

			return resultStatus;
		}

		public ResultStatus registerCard(ref UserInfo userInfo) {
			ResultStatus resultStatus;
			resultStatus = readerClient.writeUserInfo(ref userInfo);
			if(resultStatus == ResultStatus.SUCCESS) {
				MonthlyRecord rec = new();
				rec.reset();
				resultStatus = readerClient.writeMonthlyRecord(ref rec);
			}
			return resultStatus;
		}

		public ResultStatus getUserAttendanceRecordsFormRFID(out MonthlyRecord records) {
			return readerClient.readMonthlyRecord(out records);
		}

		public ResultStatus voiceOut(in string promptStr) {
			ResultStatus resultStatus;
			string paramStr = String.Format("text={0}", promptStr);
			string path = voiceSystemServerBaseURL + voiceOutAPIPath + '?' + paramStr;
			resultStatus = httpClient.doHttpRequest(path, RestSharp.Method.Post, out ServerAPIResult<Object> response);
			return resultStatus;
		}


		public ResultStatus getUserInfoFromCard(out UserInfo userInfo) {
			return readerClient.readUserInfo(out userInfo);
		}


		public ResultStatus getUserAttendanceRecordsFormServer(in uint userId,in string date,out List<AttendanceRecord> records) {
			ResultStatus resultStatus;
			records = null;
			string paramStr = String.Format("userId={0}&date={1}", userId,date);
			string path = attendanceSystemServerBaseURL + getUserAttendanceRecordsAPIPath + '?' + paramStr;
			resultStatus = httpClient.doHttpRequest(path, RestSharp.Method.Get, out ServerAPIResult<List<AttendanceRecord>> response);
			if (resultStatus == ResultStatus.SUCCESS) {
				resultStatus = (ResultStatus)response.code;
				if (response.success && resultStatus == ResultStatus.SUCCESS) {
					records = response.data;
				}
			} else {
				resultStatus = ResultStatus.SERVER_RESPONSE_TIMEOUT;
			}
			return resultStatus;
		}


		public ResultStatus getAllAttendanceRecordsFromServer(out List<AttendanceRecord> records) {
			ResultStatus resultStatus;
			records = null;
			string path = attendanceSystemServerBaseURL + getAllAttendanceRecordsAPIPath;
			resultStatus = httpClient.doHttpRequest(path, RestSharp.Method.Get, out ServerAPIResult<List<AttendanceRecord>> response);
			if (resultStatus == ResultStatus.SUCCESS) {
				resultStatus = (ResultStatus)response.code;
				if (response.success && resultStatus == ResultStatus.SUCCESS) {
					records = response.data;
				}
			} else {
				resultStatus = ResultStatus.SERVER_RESPONSE_TIMEOUT;
			}
			return resultStatus;
		}
	}
}
