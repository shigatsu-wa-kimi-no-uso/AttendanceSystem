using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using AttendanceSystemUI.Entities;
using Sunny.UI.Win32;
using AttendanceSystemUI.Controllers;

namespace AttendanceSystemUI.Forms
{
	public partial class NewInfoDialog : UIForm
	{


		public Controller controller { get; set; }
		long lastTimeClickedBtnOK = 0;

		public NewInfoDialog() {
			InitializeComponent();
			DataTable dt = new();

			dt.Columns.Add("Name");
			dt.Columns.Add("Value");
			foreach (UserRole role in Enum.GetValues(typeof(UserRole))) {
				DataRow row1 = dt.NewRow();
				row1["Name"] = role.userRoleToString();
				row1["Value"] = (int)role;
				dt.Rows.Add(row1);
			}
			cboxRole.DataSource = dt;
			cboxRole.DisplayMember = "Name";
			cboxRole.ValueMember = "Value";
		}


		private void tboxUserId_KeyPress(object sender, KeyPressEventArgs e) {
			if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar)) {
				e.Handled = true;
			}
		}

		private void tboxUserId_Validating(object sender, CancelEventArgs e) {
			UITextBox textBox = (UITextBox)sender;
			if (textBox.Text.Length > 1) {
				if (!int.TryParse(textBox.Text, out int value) || value < 0 || value > int.MaxValue) {
					e.Cancel = true;
					UIMessageBox.Show("输入值长度超出限制");
					textBox.SelectAll();
					textBox.Focus();
				}
			}
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.Cancel;
			this.Close();
		}



		private void btnOK_Click(object sender, EventArgs e) {
			DateTime currentTime = DateTime.UtcNow;
			long timestamp = (long)(currentTime.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;
			if (timestamp - lastTimeClickedBtnOK < 3000) {
				this.ShowWarningTip("您的操作太频繁，请休息一会儿");
				return;
			} else {
				lastTimeClickedBtnOK = timestamp;
			}
			UserInfo info = new();
			if (tboxUserId.Text.Length < 1) {
				this.ShowWarningTip("用户ID不能为空");
				return;
			}
			if (tboxName.Text.Length < 1) {
				this.ShowWarningTip("姓名不能为空");
				return;
			}
			info.userId = tboxUserId.Text.ToUInt();
			info.name = tboxName.Text;
			info.role = ((string)cboxRole.SelectedValue).ToInt();
			ResultStatus status = controller.registerCard(ref info);
			string promptStr = status.resultStatusToString();
			if (status == ResultStatus.SUCCESS) {
				this.ShowSuccessTip(promptStr);
			} else {
				this.ShowErrorTip(promptStr);
			}
		}

		private void tboxName_Validating(object sender, CancelEventArgs e) {
			UITextBox textBox = (UITextBox)sender;
			if (textBox.Text.Length > 12) {
				e.Cancel = true;
				UIMessageBox.Show("姓名长度超出限制");
				textBox.SelectAll();
				textBox.Focus();
			}
		}
	}
}
