using AttendanceSystemUI.Clients;
using AttendanceSystemUI.Entities;
using Sunny.UI;
using AttendanceSystemUI.Controllers;
using AttendanceSystemUI.Dialogs;

namespace AttendanceSystemUI.Forms
{

	public partial class MainForm : UIForm
	{
		bool guestOperating;
		GuestAction guestAction;
		long btnControlClickedTime = DateTime.Now.Second;
		string lblPrompt1TextFmt = "请在{0}秒内将RFID卡靠近读卡器";
		int guestOperationTimeLimit = 8;
		public Controller controller { get; set; }

		public MainForm() {
			InitializeComponent();
			timer1.Start();
			lblPrompt1.Visible = false;
		}

		private void enterGuestOperatingMode(GuestAction guestAction) {
			this.guestAction = guestAction;
			guestOperating = true;
			btnControlClickedTime = DateTime.Now.SecondsSince1970();
			lblPrompt1.Text = String.Format(lblPrompt1TextFmt, guestOperationTimeLimit);
			lblPrompt1.Visible = true;
			btnLogin.Visible = false;
			btnLogout.Visible = false;
			btnQuery.Visible = false;
		}

		private void quitGuestOperatingMode() {
			lblPrompt1.Visible = false;
			guestOperating = false;
			btnLogin.Visible = true;
			btnLogout.Visible = true;
			btnQuery.Visible = true;
		}

		private ResultStatus pollingReadCard(out UserInfo userInfo, out CheckTime checkTime) {
			checkTime = null;
			userInfo = default;
			if (guestAction == GuestAction.LOGIN) {
				return controller.userLoginByCard(out userInfo, out checkTime);
			} else if (guestAction == GuestAction.LOGOUT) {
				return controller.userLogoutByCard(out userInfo, out checkTime);
			}
			return ResultStatus.UNDEFINED_ERROR;
		}

		string getPromptString(in UserInfo userInfo, in CheckTime checkTime, in ResultStatus status) {
			string promptStr = "{0}打卡成功，{1}，{2}，您的打卡时间为{3}";
			switch (status) {
				case ResultStatus.SUCCESS:
					if (GuestAction.LOGIN.Equals(guestAction)) {
						promptStr = String.Format(promptStr, "上班", "欢迎您", userInfo.name, checkTime.checkTime);
					} else if (GuestAction.LOGOUT.Equals(guestAction)) {
						promptStr = String.Format(promptStr, "下班", "欢迎您", userInfo.name, checkTime.checkTime);
						promptStr += "，本次出勤共工作了" + checkTime.workingTime.workingTimeToString();
						promptStr += "，今日共出勤" + checkTime.workingTimeToday.workingTimeToString();
					}
					break;
				default:
					promptStr = status.resultStatusToString();
					break;
			}

			return promptStr;
		}

		private void timer1_Tick(object sender, EventArgs e) {
			DateTime now = DateTime.Now;
			pnlCurrTime.Text = now.DateTimeString();
			if (guestOperating) {
				long secondRemaining = guestOperationTimeLimit - (now.SecondsSince1970() - btnControlClickedTime);
				lblPrompt1.Text = String.Format(lblPrompt1TextFmt, secondRemaining);
				ResultStatus status = pollingReadCard(out UserInfo userInfo, out CheckTime checkTime);
				string promptStr = getPromptString(userInfo, checkTime, status);
				if (status == ResultStatus.SUCCESS) {
					quitGuestOperatingMode();
					controller.voiceOut(promptStr);
					this.ShowSuccessDialog(promptStr, true, 5000);
					return;
				}
				if (status != ResultStatus.READER_NO_CARD) {
					quitGuestOperatingMode();
					controller.voiceOut(promptStr);
					this.ShowErrorDialog(promptStr, true, 5000);
					return;
				}
				if (secondRemaining < 0) {
					quitGuestOperatingMode();
					this.ShowErrorDialog("未检测到RFID卡", true, 5000);
					return;
				}
			}

		}



		private void btnLogin_Click(object sender, EventArgs e) {
			enterGuestOperatingMode(GuestAction.LOGIN);
		}

		private void btnLogout_Click(object sender, EventArgs e) {
			enterGuestOperatingMode(GuestAction.LOGOUT);
		}

		private void btnQuery_Click(object sender, EventArgs e) {
			UserQueryRecordDialog dlg = new() { controller = controller};
			dlg.ShowDialog();
		}
	}
}
