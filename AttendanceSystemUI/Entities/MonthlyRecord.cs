using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystemUI.Entities
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct MonthlyRecord
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] workingTimes1;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] workingTimes2;

		public long lastUpdateTimestamp;

		public void setWorkingTime(int day, int hours, int minutes) {
			byte dec = (byte)(minutes / 7.5);
			byte b = (byte)((hours << 3) | dec);
			if (day > 15) {
				workingTimes2[day - 16] = b;
			} else {
				workingTimes1[day] = b;
			}
		}

		public void getWorkingTime(int day, out int hours, out int minutes) {
			if (day > 15) {
				hours = (byte)(workingTimes2[day - 16] & 0b11111000) >> 3;
				minutes = (byte)(workingTimes2[day - 16] & 0b00000111);
				minutes = (int)(minutes * 7.5);
			} else {
				hours = (byte)(workingTimes1[day] & 0b11111000) >> 3;
				minutes = (byte)(workingTimes1[day] & 0b00000111);
				minutes = (int)(minutes * 7.5);
			}
		}

		public void reset() {
			workingTimes1 = new byte[16];
			workingTimes2 = new byte[16];
			lastUpdateTimestamp = DateTime.Now.getTimestampMillis();
		}
	}
}
