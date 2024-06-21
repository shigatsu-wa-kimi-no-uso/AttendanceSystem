using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AttendanceSystemUI.Controllers;
using Sunny.UI;
using AttendanceSystemUI.Dialogs;
using AttendanceSystemUI.Entities;

namespace AttendanceSystemUI.Forms
{
	public partial class AdminForm : UIForm
	{
		public AdminForm() {
			InitializeComponent();
		}

		private void btnNewInfo_Click(object sender, EventArgs e) {
			NewInfoDialog dlg = new() {
				controller = controller
			};
			dlg.ShowDialog();

		}

		private void btnShowRecords_Click(object sender, EventArgs e) {
			controller.getAllAttendanceRecordsFromServer(out List<AttendanceRecord> dataList);
			ShowRecordsDialog dlg = new(dataList);
			dlg.ShowDialog();
		}

		public Controller controller { get; set; }

	}
}
