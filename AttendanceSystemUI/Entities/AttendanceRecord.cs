using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystemUI.Entities
{
	public class AttendanceRecord
	{
		public int recordId { get; set; }

		public int staffId { get; set; }

		public int type { get; set; }  //登入为0 登出为1

		public DateTime recordTime { get; set; }

		public int cardId { get; set; }

		public string name { get; set; }

		public int role { get; set; }

	}
}
