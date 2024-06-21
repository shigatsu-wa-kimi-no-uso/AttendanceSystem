using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystemUI.Entities
{
	public class ServerAPIResult<T>
	{
		public bool success { get; set; }
		public int code { get; set; }
		public T data { get; set; }
		public string message { get; set; }
	}
}
