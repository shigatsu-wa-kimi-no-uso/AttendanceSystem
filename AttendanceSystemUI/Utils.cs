using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using AttendanceSystemUI.Entities;

namespace AttendanceSystemUI
{
	public static class Utils
	{
		public static string modelToURIParam(this object obj, string url = "") {
			PropertyInfo[] propertis = obj.GetType().GetProperties();
			StringBuilder sb = new();
			sb.Append(url);
			sb.Append("?");
			foreach (var p in propertis) {
				var v = p.GetValue(obj, null);
				if (v == null)
					continue;

				sb.Append(p.Name);
				sb.Append("=");
				sb.Append(HttpUtility.UrlEncode(v.ToString()));
				sb.Append("&");
			}
			sb.Remove(sb.Length - 1, 1);

			return sb.ToString();
		}

		public static string toJson(this object obj) {
			return JsonConvert.SerializeObject(obj);
		}

		public static T jsonToObject<T>(this string json) {
			return JsonConvert.DeserializeObject<T>(json);
		}

		public static string userRoleToString(this UserRole role) {
			return role switch {
				UserRole.NORMAL_EMPLOYEE => "普通员工",
				UserRole.ADMIN => "管理员",
				UserRole.INTERN => "实习生",
				_ => "",
			};
		}

		public static string guestActionToString(this GuestAction action) {
			return action switch {
				GuestAction.LOGIN => "上班",
				GuestAction.LOGOUT => "下班",
				_ => "",
			};
		}



		public static string workingTimeToString(this WorkingTime workingTime) {
			return string.Format("{0}小时{1}分钟{2}秒", workingTime.hours, workingTime.minutes, workingTime.seconds);
		}

		public static string resultStatusToString(this ResultStatus status) {
			return status switch {
				ResultStatus.SUCCESS => "操作成功",
				ResultStatus.SERVER_RESPONSE_TIMEOUT => "服务器响应超时",
				ResultStatus.SERVER_ERROR => "服务器异常",
				ResultStatus.INTEGRITY_ERROR => "IC卡数据与系统数据库中的数据不匹配，请勿使用盗刷卡！",
				ResultStatus.DUPLICATE_LOGIN => "您已经打卡上班，请不要重复打卡",
				ResultStatus.DUPLICATE_LOGOUT => "您已经打卡下班，请不要重复打卡",
				ResultStatus.UNDEFINED_ERROR => "未知错误",
				ResultStatus.READER_OPENPORT_FAILED => "初始化串口失败，请检查读写器端口是否配置正确，或者是否被其它软件打开占用！",
				ResultStatus.NOT_REGISTERED => "您非本单位员工或信息尚未在系统中注册，无法进入",
				ResultStatus.NO_PERMISSION => "您的权限不够，无法操作",
				ResultStatus.NO_CONTENT => "服务器未响应任何内容",
				ResultStatus.READER_TIMEOUT => "读卡超时，请检查读卡器的连接是否正常！",
				ResultStatus.READER_BAD_TRANSMISSION => "读卡器返回的数据包损坏，请检查周围环境是否有干扰源，或读卡器是否已损坏",
				ResultStatus.READER_NO_CARD => "未检测到RFID卡",
				ResultStatus.READER_FAIL => "读卡器响应超时，请检查读卡器的连接是否正常！",
				_ => "",
			};
		}


		public static DateTime getDateTime(this long timestamp) {
			return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddMilliseconds(timestamp);
		}

		public static long getTimestampMillis(this DateTime dateTime) {
			return (dateTime.ToUniversalTime().Ticks - 621355968000000000) / 10000;
		}
	}
}
