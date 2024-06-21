using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttendanceSystemUI.Entities;
using Sunny.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using Sunny.UI.Win32;
using AttendanceSystemUI.Controllers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AttendanceSystemUI.Dialogs
{
	public partial class UserQueryRecordDialog : UIForm
	{

		DataTable dataTable = new("Records2");
		bool queryFromServer = false;
		long btnQueryFromRFIDClickedTime = 0;
		bool guestRequestingRFID = false;
		long guestOperationTimeLimit = 8;
		string lblPrompt2TextFmt = "请在{0}秒内将RFID卡靠近读卡器";
		public Controller controller { get; set; }

		public UserQueryRecordDialog() {
			InitializeComponent();
			lblPrompt2.Visible = false;
			timer1.Start();
		}

		ResultStatus polling(out UserInfo info, out MonthlyRecord monthlyRecord) {
			info = default;
			monthlyRecord = default;
			ResultStatus status = controller.getUserInfoFromCard(out info);
			if (status == ResultStatus.SUCCESS) {
				status = controller.getUserAttendanceRecordsFormRFID(out monthlyRecord);
			}
			return status;
		}

		private void enterGuestOperatingMode(bool queryFromServer) {
			guestRequestingRFID = true;
			btnQueryFromRFIDClickedTime = DateTime.Now.SecondsSince1970();
			lblPrompt2.Text = String.Format(lblPrompt2TextFmt, guestOperationTimeLimit);
			lblPrompt2.Visible = true;
			btnQueryFromRFID.Visible = false;
			btnQueryFromServer.Visible = false;
			this.queryFromServer = queryFromServer;
		}

		private void quitGuestOperatingMode() {
			guestRequestingRFID = false;
			lblPrompt2.Visible = false;
			btnQueryFromRFID.Visible = true;
			btnQueryFromServer.Visible = true;
		}

		private void btnQueryFromRFID_Click(object sender, EventArgs e) {
			enterGuestOperatingMode(false);
		}

		private void btnQueryFromServer_Click(object sender, EventArgs e) {
			enterGuestOperatingMode(true);
		}

		void fillGrid(in int day, in UserInfo info, in MonthlyRecord monthlyRecord) {
			monthlyRecord.getWorkingTime(day, out int hours, out int minutes);
			dataTable.Columns.Clear();
			dataTable.Columns.Add("员工ID", typeof(uint));
			dataTable.Columns.Add("卡号", typeof(uint));
			dataTable.Columns.Add("姓名", typeof(string));
			dataTable.Columns.Add("角色", typeof(string));
			dataTable.Columns.Add("出勤时间", typeof(string));
			dataTable.Rows.Clear();
			string t = string.Format("约{0}小时{1}分钟", hours, minutes);
			dataTable.Rows.Add(info.userId, info.cardId, info.name, ((UserRole)info.role).userRoleToString(), t);
			dgAttendanceRecord.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgAttendanceRecord.AllowUserToAddRows = false;
			dgAttendanceRecord.ReadOnly = true;
			//不自动生成列
			dgAttendanceRecord.AutoGenerateColumns = true;
			dgAttendanceRecord.DataSource = dataTable;

		}

		void fillGrid(in int day, in List<AttendanceRecord> records) {
			dataTable.Columns.Clear();
			dataTable.Columns.Add("记录号", typeof(int));
			dataTable.Columns.Add("员工ID", typeof(int));
			dataTable.Columns.Add("卡号", typeof(uint));
			dataTable.Columns.Add("姓名", typeof(string));
			dataTable.Columns.Add("角色", typeof(string));
			dataTable.Columns.Add("类型", typeof(string));
			dataTable.Columns.Add("记录时间", typeof(string));
			dataTable.Rows.Clear();
			foreach (AttendanceRecord record in records) {
				UserRole role = (UserRole)record.role;
				string time = record.recordTime.ToString("yyyy-MM-dd HH:mm:ss");
				GuestAction action = (GuestAction)record.type;
				dataTable.Rows.Add(record.recordId, record.staffId, record.cardId, record.name, role.userRoleToString(), action.guestActionToString(), time);
			}
			dgAttendanceRecord.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgAttendanceRecord.AllowUserToAddRows = false;
			dgAttendanceRecord.ReadOnly = true;
			//不自动生成列
			dgAttendanceRecord.AutoGenerateColumns = true;
			dgAttendanceRecord.DataSource = dataTable;

		}

		private void timer1_Tick(object sender, EventArgs e) {
			if (guestRequestingRFID) {
				long secondRemaining = guestOperationTimeLimit - (DateTime.Now.SecondsSince1970() - btnQueryFromRFIDClickedTime);
				lblPrompt2.Text = String.Format(lblPrompt2TextFmt, secondRemaining);
				if (secondRemaining > 0) {
					ResultStatus status = polling(out UserInfo info, out MonthlyRecord monthlyRecords);
					List<AttendanceRecord> records = new();
					int day = uiDatePicker1.Value.Day;
					if (status == ResultStatus.SUCCESS && queryFromServer) {
						status = controller.getUserAttendanceRecordsFormServer(info.userId, uiDatePicker1.Text, out records);
					}
					if (status == ResultStatus.SUCCESS) {
						if (queryFromServer) {
							fillGrid(day, records);
						} else {
							fillGrid(day, info, monthlyRecords);
						}
						quitGuestOperatingMode();
						this.ShowSuccessTip(status.resultStatusToString());
					} else if (status != ResultStatus.READER_NO_CARD) {
						quitGuestOperatingMode();
						this.ShowErrorDialog(status.resultStatusToString(), true, 5000);
					}
				} else {
					quitGuestOperatingMode();
					this.ShowErrorDialog(ResultStatus.READER_NO_CARD.resultStatusToString(), true, 5000);
				}
			}
		}
	}
}
