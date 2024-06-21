namespace AttendanceSystemUI.Forms
{
	partial class AdminForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			btnNewInfo = new Sunny.UI.UIButton();
			lblWelcome = new Sunny.UI.UILabel();
			btnShowRecords = new Sunny.UI.UIButton();
			SuspendLayout();
			// 
			// btnNewInfo
			// 
			btnNewInfo.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnNewInfo.Location = new Point(67, 219);
			btnNewInfo.MinimumSize = new Size(1, 1);
			btnNewInfo.Name = "btnNewInfo";
			btnNewInfo.Size = new Size(111, 35);
			btnNewInfo.TabIndex = 0;
			btnNewInfo.Text = "注册IC卡";
			btnNewInfo.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point);
			btnNewInfo.Click += btnNewInfo_Click;
			// 
			// lblWelcome
			// 
			lblWelcome.Font = new Font("黑体", 18F, FontStyle.Regular, GraphicsUnit.Point);
			lblWelcome.ForeColor = Color.FromArgb(64, 128, 205);
			lblWelcome.Location = new Point(67, 78);
			lblWelcome.Name = "lblWelcome";
			lblWelcome.Size = new Size(314, 23);
			lblWelcome.TabIndex = 3;
			lblWelcome.Text = "欢迎使用考勤系统管理端！";
			lblWelcome.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// btnShowRecords
			// 
			btnShowRecords.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnShowRecords.Location = new Point(315, 219);
			btnShowRecords.MinimumSize = new Size(1, 1);
			btnShowRecords.Name = "btnShowRecords";
			btnShowRecords.Size = new Size(119, 35);
			btnShowRecords.TabIndex = 4;
			btnShowRecords.Text = "查看考勤记录";
			btnShowRecords.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point);
			btnShowRecords.Click += btnShowRecords_Click;
			// 
			// AdminForm
			// 
			AutoScaleMode = AutoScaleMode.None;
			ClientSize = new Size(513, 316);
			Controls.Add(btnShowRecords);
			Controls.Add(lblWelcome);
			Controls.Add(btnNewInfo);
			MaximizeBox = false;
			Name = "AdminForm";
			Text = "考勤系统管理端 戴安邦 许金晨";
			ZoomScaleRect = new Rectangle(15, 15, 800, 450);
			ResumeLayout(false);
		}

		#endregion

		private Sunny.UI.UIButton btnNewInfo;
		private Sunny.UI.UILabel lblWelcome;
		private Sunny.UI.UIButton btnShowRecords;
	}
}