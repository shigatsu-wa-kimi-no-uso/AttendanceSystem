namespace AttendanceSystemUI.Forms
{
	partial class MainForm
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
			components = new System.ComponentModel.Container();
			btnLogin = new Sunny.UI.UIButton();
			btnLogout = new Sunny.UI.UIButton();
			lblWelcome = new Sunny.UI.UILabel();
			timer1 = new System.Windows.Forms.Timer(components);
			pnlCurrTime = new Sunny.UI.UIPanel();
			lblCurrTime = new Sunny.UI.UILabel();
			lblPrompt1 = new Sunny.UI.UILabel();
			btnQuery = new Sunny.UI.UIButton();
			SuspendLayout();
			// 
			// btnLogin
			// 
			btnLogin.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnLogin.Location = new Point(84, 217);
			btnLogin.MinimumSize = new Size(1, 1);
			btnLogin.Name = "btnLogin";
			btnLogin.Size = new Size(100, 35);
			btnLogin.TabIndex = 0;
			btnLogin.Text = "我要上班";
			btnLogin.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point);
			btnLogin.Click += btnLogin_Click;
			// 
			// btnLogout
			// 
			btnLogout.FillColor = Color.FromArgb(220, 155, 40);
			btnLogout.FillColor2 = Color.FromArgb(220, 155, 40);
			btnLogout.FillHoverColor = Color.FromArgb(227, 175, 83);
			btnLogout.FillPressColor = Color.FromArgb(176, 124, 32);
			btnLogout.FillSelectedColor = Color.FromArgb(176, 124, 32);
			btnLogout.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnLogout.Location = new Point(245, 217);
			btnLogout.MinimumSize = new Size(1, 1);
			btnLogout.Name = "btnLogout";
			btnLogout.RectColor = Color.FromArgb(220, 155, 40);
			btnLogout.RectHoverColor = Color.FromArgb(227, 175, 83);
			btnLogout.RectPressColor = Color.FromArgb(176, 124, 32);
			btnLogout.RectSelectedColor = Color.FromArgb(176, 124, 32);
			btnLogout.Size = new Size(100, 35);
			btnLogout.TabIndex = 1;
			btnLogout.Text = "我要下班";
			btnLogout.Click += btnLogout_Click;
			// 
			// lblWelcome
			// 
			lblWelcome.Font = new Font("黑体", 18F, FontStyle.Regular, GraphicsUnit.Point);
			lblWelcome.ForeColor = Color.FromArgb(64, 128, 205);
			lblWelcome.Location = new Point(84, 58);
			lblWelcome.Name = "lblWelcome";
			lblWelcome.Size = new Size(283, 23);
			lblWelcome.TabIndex = 2;
			lblWelcome.Text = "欢迎使用考勤系统！";
			lblWelcome.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// timer1
			// 
			timer1.Tick += timer1_Tick;
			// 
			// pnlCurrTime
			// 
			pnlCurrTime.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			pnlCurrTime.Location = new Point(191, 119);
			pnlCurrTime.Margin = new Padding(4, 5, 4, 5);
			pnlCurrTime.MinimumSize = new Size(1, 1);
			pnlCurrTime.Name = "pnlCurrTime";
			pnlCurrTime.Size = new Size(262, 42);
			pnlCurrTime.TabIndex = 3;
			pnlCurrTime.Text = "currTime";
			pnlCurrTime.TextAlignment = ContentAlignment.MiddleCenter;
			// 
			// lblCurrTime
			// 
			lblCurrTime.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lblCurrTime.ForeColor = Color.FromArgb(64, 128, 205);
			lblCurrTime.Location = new Point(84, 128);
			lblCurrTime.Name = "lblCurrTime";
			lblCurrTime.Size = new Size(100, 23);
			lblCurrTime.TabIndex = 4;
			lblCurrTime.Text = "当前时间：";
			lblCurrTime.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// lblPrompt1
			// 
			lblPrompt1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lblPrompt1.ForeColor = Color.FromArgb(64, 128, 205);
			lblPrompt1.Location = new Point(84, 191);
			lblPrompt1.Name = "lblPrompt1";
			lblPrompt1.Size = new Size(283, 23);
			lblPrompt1.TabIndex = 5;
			lblPrompt1.Text = "请在{0}内将RFID卡靠近读卡器";
			lblPrompt1.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// btnQuery
			// 
			btnQuery.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnQuery.Location = new Point(400, 217);
			btnQuery.MinimumSize = new Size(1, 1);
			btnQuery.Name = "btnQuery";
			btnQuery.Size = new Size(119, 35);
			btnQuery.TabIndex = 6;
			btnQuery.Text = "查询出勤情况";
			btnQuery.Click += btnQuery_Click;
			// 
			// MainForm
			// 
			AutoScaleMode = AutoScaleMode.None;
			ClientSize = new Size(592, 315);
			Controls.Add(btnQuery);
			Controls.Add(lblPrompt1);
			Controls.Add(lblCurrTime);
			Controls.Add(pnlCurrTime);
			Controls.Add(lblWelcome);
			Controls.Add(btnLogout);
			Controls.Add(btnLogin);
			MaximizeBox = false;
			Name = "MainForm";
			Text = "考勤系统 戴安邦 许金晨";
			ZoomScaleRect = new Rectangle(15, 15, 521, 315);
			ResumeLayout(false);
		}

		#endregion

		private Sunny.UI.UIButton btnLogin;
		private Sunny.UI.UIButton btnLogout;
		private Sunny.UI.UILabel lblWelcome;
		private System.Windows.Forms.Timer timer1;
		private Sunny.UI.UIPanel pnlCurrTime;
		private Sunny.UI.UILabel lblCurrTime;
		private Sunny.UI.UILabel lblPrompt1;
		private Sunny.UI.UIButton btnQuery;
	}
}