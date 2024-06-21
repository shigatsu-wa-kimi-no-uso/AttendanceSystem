using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystemUI.Entities
{
	public class CheckTime
	{
		public string checkTime { get; set; }

		public WorkingTime workingTime { get; set; }

		public WorkingTime workingTimeToday { get; set;}
	}
}
