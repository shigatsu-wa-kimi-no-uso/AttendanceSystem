using AttendanceSystemUI.Clients;
using AttendanceSystemUI.Entities;
using AttendanceSystemUI.Forms;
using AttendanceSystemUI.Controllers;

namespace AttendanceSystemUI
{
    internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			//RFIDReaderClient client = new RFIDReaderClient();
			//UserInfo info = new UserInfo();
			//info.name = "ะกอ๕";
			//info.userId = 1;
			//info.role = 0;
			//client.writeUserInfo(ref info);
			ApplicationConfiguration.Initialize();
			AdminForm form = new() { controller = new() };
			//MainForm form = new() {	controller = new()};
			Application.Run(form);
		}
	}
}