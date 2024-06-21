namespace AttendanceSystemUI.Forms
{
	partial class NewInfoDialog
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
			btnOK = new Sunny.UI.UIButton();
			btnCancel = new Sunny.UI.UIButton();
			tboxUserId = new Sunny.UI.UITextBox();
			lblName = new Sunny.UI.UILabel();
			tboxName = new Sunny.UI.UITextBox();
			lblUserId = new Sunny.UI.UILabel();
			cboxRole = new Sunny.UI.UIComboBox();
			lblRole = new Sunny.UI.UILabel();
			SuspendLayout();
			// 
			// btnOK
			// 
			btnOK.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnOK.Location = new Point(55, 217);
			btnOK.MinimumSize = new Size(1, 1);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(100, 35);
			btnOK.TabIndex = 0;
			btnOK.Text = "确定";
			btnOK.Click += btnOK_Click;
			// 
			// btnCancel
			// 
			btnCancel.FillColor = Color.FromArgb(220, 155, 40);
			btnCancel.FillColor2 = Color.FromArgb(220, 155, 40);
			btnCancel.FillHoverColor = Color.FromArgb(227, 175, 83);
			btnCancel.FillPressColor = Color.FromArgb(176, 124, 32);
			btnCancel.FillSelectedColor = Color.FromArgb(176, 124, 32);
			btnCancel.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnCancel.Location = new Point(246, 217);
			btnCancel.MinimumSize = new Size(1, 1);
			btnCancel.Name = "btnCancel";
			btnCancel.RectColor = Color.FromArgb(220, 155, 40);
			btnCancel.RectHoverColor = Color.FromArgb(227, 175, 83);
			btnCancel.RectPressColor = Color.FromArgb(176, 124, 32);
			btnCancel.RectSelectedColor = Color.FromArgb(176, 124, 32);
			btnCancel.Size = new Size(100, 35);
			btnCancel.TabIndex = 2;
			btnCancel.Text = "取消";
			btnCancel.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point);
			btnCancel.Click += btnCancel_Click;
			// 
			// tboxUserId
			// 
			tboxUserId.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			tboxUserId.Location = new Point(135, 55);
			tboxUserId.Margin = new Padding(4, 5, 4, 5);
			tboxUserId.MinimumSize = new Size(1, 16);
			tboxUserId.Name = "tboxUserId";
			tboxUserId.Padding = new Padding(5);
			tboxUserId.ShowText = false;
			tboxUserId.Size = new Size(184, 28);
			tboxUserId.TabIndex = 3;
			tboxUserId.TextAlignment = ContentAlignment.MiddleLeft;
			tboxUserId.Watermark = "";
			tboxUserId.Validating += tboxUserId_Validating;
			tboxUserId.KeyPress += tboxUserId_KeyPress;
			// 
			// lblName
			// 
			lblName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lblName.ForeColor = Color.FromArgb(48, 48, 48);
			lblName.Location = new Point(55, 112);
			lblName.Name = "lblName";
			lblName.Size = new Size(45, 23);
			lblName.TabIndex = 4;
			lblName.Text = "姓名";
			lblName.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// tboxName
			// 
			tboxName.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			tboxName.Location = new Point(135, 112);
			tboxName.Margin = new Padding(4, 5, 4, 5);
			tboxName.MinimumSize = new Size(1, 16);
			tboxName.Name = "tboxName";
			tboxName.Padding = new Padding(5);
			tboxName.ShowText = false;
			tboxName.Size = new Size(184, 28);
			tboxName.TabIndex = 5;
			tboxName.TextAlignment = ContentAlignment.MiddleLeft;
			tboxName.Watermark = "";
			tboxName.Validating += tboxName_Validating;
			// 
			// lblUserId
			// 
			lblUserId.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lblUserId.ForeColor = Color.FromArgb(48, 48, 48);
			lblUserId.Location = new Point(55, 55);
			lblUserId.Name = "lblUserId";
			lblUserId.Size = new Size(73, 23);
			lblUserId.TabIndex = 6;
			lblUserId.Text = "员工ID";
			lblUserId.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// cboxRole
			// 
			cboxRole.DataSource = null;
			cboxRole.FillColor = Color.White;
			cboxRole.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			cboxRole.ItemHoverColor = Color.FromArgb(155, 200, 255);
			cboxRole.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
			cboxRole.Location = new Point(135, 166);
			cboxRole.Margin = new Padding(4, 5, 4, 5);
			cboxRole.MinimumSize = new Size(63, 0);
			cboxRole.Name = "cboxRole";
			cboxRole.Padding = new Padding(0, 0, 30, 2);
			cboxRole.Size = new Size(184, 29);
			cboxRole.SymbolSize = 24;
			cboxRole.TabIndex = 7;
			cboxRole.TextAlignment = ContentAlignment.MiddleLeft;
			cboxRole.Watermark = "";
			// 
			// lblRole
			// 
			lblRole.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lblRole.ForeColor = Color.FromArgb(48, 48, 48);
			lblRole.Location = new Point(55, 172);
			lblRole.Name = "lblRole";
			lblRole.Size = new Size(45, 23);
			lblRole.TabIndex = 8;
			lblRole.Text = "角色";
			lblRole.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// NewInfoDialog
			// 
			AutoScaleMode = AutoScaleMode.None;
			ClientSize = new Size(403, 303);
			Controls.Add(lblRole);
			Controls.Add(cboxRole);
			Controls.Add(lblUserId);
			Controls.Add(tboxName);
			Controls.Add(lblName);
			Controls.Add(tboxUserId);
			Controls.Add(btnCancel);
			Controls.Add(btnOK);
			MaximizeBox = false;
			Name = "NewInfoDialog";
			ShowIcon = false;
			ShowInTaskbar = false;
			Text = "注册RFID卡";
			ZoomScaleRect = new Rectangle(15, 15, 800, 450);
			ResumeLayout(false);
		}

		#endregion

		private Sunny.UI.UIButton btnOK;
		private Sunny.UI.UIButton btnCancel;
		private Sunny.UI.UITextBox tboxUserId;
		private Sunny.UI.UILabel lblName;
		private Sunny.UI.UITextBox tboxName;
		private Sunny.UI.UILabel lblUserId;
		private Sunny.UI.UIComboBox cboxRole;
		private Sunny.UI.UILabel lblRole;
	}
}