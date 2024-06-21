namespace AttendanceSystemUI.Dialogs
{
	partial class UserQueryRecordDialog
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
			DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
			btnQueryFromRFID = new Sunny.UI.UIButton();
			dgAttendanceRecord = new Sunny.UI.UIDataGridView();
			btnQueryFromServer = new Sunny.UI.UIButton();
			uiDatePicker1 = new Sunny.UI.UIDatePicker();
			lblSelectDate = new Sunny.UI.UILabel();
			lblPrompt1 = new Sunny.UI.UILabel();
			lblPrompt3 = new Sunny.UI.UILabel();
			lblPrompt2 = new Sunny.UI.UILabel();
			timer1 = new System.Windows.Forms.Timer(components);
			((System.ComponentModel.ISupportInitialize)dgAttendanceRecord).BeginInit();
			SuspendLayout();
			// 
			// btnQueryFromRFID
			// 
			btnQueryFromRFID.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnQueryFromRFID.Location = new Point(408, 313);
			btnQueryFromRFID.MinimumSize = new Size(1, 1);
			btnQueryFromRFID.Name = "btnQueryFromRFID";
			btnQueryFromRFID.Size = new Size(120, 35);
			btnQueryFromRFID.TabIndex = 1;
			btnQueryFromRFID.Text = "从RFID卡查询";
			btnQueryFromRFID.Click += btnQueryFromRFID_Click;
			// 
			// dgAttendanceRecord
			// 
			dataGridViewCellStyle6.BackColor = Color.FromArgb(235, 243, 255);
			dgAttendanceRecord.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
			dgAttendanceRecord.BackgroundColor = Color.White;
			dgAttendanceRecord.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle7.BackColor = Color.FromArgb(80, 160, 255);
			dataGridViewCellStyle7.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle7.ForeColor = Color.White;
			dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
			dgAttendanceRecord.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
			dgAttendanceRecord.ColumnHeadersHeight = 32;
			dgAttendanceRecord.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = SystemColors.Window;
			dataGridViewCellStyle8.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle8.ForeColor = Color.FromArgb(48, 48, 48);
			dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
			dgAttendanceRecord.DefaultCellStyle = dataGridViewCellStyle8;
			dgAttendanceRecord.EnableHeadersVisualStyles = false;
			dgAttendanceRecord.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			dgAttendanceRecord.GridColor = Color.FromArgb(80, 160, 255);
			dgAttendanceRecord.Location = new Point(40, 50);
			dgAttendanceRecord.Name = "dgAttendanceRecord";
			dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle9.BackColor = Color.FromArgb(235, 243, 255);
			dataGridViewCellStyle9.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle9.ForeColor = Color.FromArgb(48, 48, 48);
			dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(80, 160, 255);
			dataGridViewCellStyle9.SelectionForeColor = Color.White;
			dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
			dgAttendanceRecord.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
			dataGridViewCellStyle10.BackColor = Color.White;
			dataGridViewCellStyle10.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			dgAttendanceRecord.RowsDefaultCellStyle = dataGridViewCellStyle10;
			dgAttendanceRecord.RowTemplate.Height = 25;
			dgAttendanceRecord.SelectedIndex = -1;
			dgAttendanceRecord.Size = new Size(453, 214);
			dgAttendanceRecord.StripeOddColor = Color.FromArgb(235, 243, 255);
			dgAttendanceRecord.TabIndex = 2;
			// 
			// btnQueryFromServer
			// 
			btnQueryFromServer.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnQueryFromServer.Location = new Point(587, 313);
			btnQueryFromServer.MinimumSize = new Size(1, 1);
			btnQueryFromServer.Name = "btnQueryFromServer";
			btnQueryFromServer.Size = new Size(120, 35);
			btnQueryFromServer.TabIndex = 3;
			btnQueryFromServer.Text = "从服务器查询";
			btnQueryFromServer.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point);
			btnQueryFromServer.Click += btnQueryFromServer_Click;
			// 
			// uiDatePicker1
			// 
			uiDatePicker1.FillColor = Color.White;
			uiDatePicker1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			uiDatePicker1.Location = new Point(525, 228);
			uiDatePicker1.Margin = new Padding(4, 5, 4, 5);
			uiDatePicker1.MaxLength = 10;
			uiDatePicker1.MinimumSize = new Size(63, 0);
			uiDatePicker1.Name = "uiDatePicker1";
			uiDatePicker1.Padding = new Padding(0, 0, 30, 2);
			uiDatePicker1.Size = new Size(150, 29);
			uiDatePicker1.SymbolDropDown = 61555;
			uiDatePicker1.SymbolNormal = 61555;
			uiDatePicker1.SymbolSize = 24;
			uiDatePicker1.TabIndex = 4;
			uiDatePicker1.Text = "2024-06-19";
			uiDatePicker1.TextAlignment = ContentAlignment.MiddleLeft;
			uiDatePicker1.Value = new DateTime(2024, 6, 19, 17, 29, 7, 593);
			uiDatePicker1.Watermark = "";
			// 
			// lblSelectDate
			// 
			lblSelectDate.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lblSelectDate.ForeColor = Color.FromArgb(64, 128, 205);
			lblSelectDate.Location = new Point(522, 187);
			lblSelectDate.Name = "lblSelectDate";
			lblSelectDate.Size = new Size(100, 23);
			lblSelectDate.TabIndex = 5;
			lblSelectDate.Text = "选择日期：";
			lblSelectDate.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// lblPrompt1
			// 
			lblPrompt1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lblPrompt1.ForeColor = Color.FromArgb(64, 128, 205);
			lblPrompt1.Location = new Point(524, 50);
			lblPrompt1.Name = "lblPrompt1";
			lblPrompt1.Size = new Size(202, 65);
			lblPrompt1.TabIndex = 6;
			lblPrompt1.Text = "从RFID卡查询只能读取自然月内每天出勤大致时间，精确到7.5分钟";
			lblPrompt1.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// lblPrompt3
			// 
			lblPrompt3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lblPrompt3.ForeColor = Color.FromArgb(64, 128, 205);
			lblPrompt3.Location = new Point(523, 115);
			lblPrompt3.Name = "lblPrompt3";
			lblPrompt3.Size = new Size(202, 52);
			lblPrompt3.TabIndex = 7;
			lblPrompt3.Text = "从服务器查询可获取精确出勤记录";
			lblPrompt3.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// lblPrompt2
			// 
			lblPrompt2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lblPrompt2.ForeColor = Color.FromArgb(64, 128, 205);
			lblPrompt2.Location = new Point(60, 306);
			lblPrompt2.Name = "lblPrompt2";
			lblPrompt2.Size = new Size(249, 42);
			lblPrompt2.TabIndex = 8;
			lblPrompt2.Text = "请在{0}秒内将RFID卡靠近读卡器";
			lblPrompt2.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// timer1
			// 
			timer1.Tick += timer1_Tick;
			// 
			// UserQueryRecordDialog
			// 
			AutoScaleMode = AutoScaleMode.None;
			ClientSize = new Size(831, 377);
			Controls.Add(lblPrompt2);
			Controls.Add(lblPrompt3);
			Controls.Add(lblPrompt1);
			Controls.Add(lblSelectDate);
			Controls.Add(uiDatePicker1);
			Controls.Add(btnQueryFromServer);
			Controls.Add(dgAttendanceRecord);
			Controls.Add(btnQueryFromRFID);
			MaximizeBox = false;
			Name = "UserQueryRecordDialog";
			ShowIcon = false;
			ShowInTaskbar = false;
			Text = "查询出勤情况";
			ZoomScaleRect = new Rectangle(15, 15, 800, 450);
			((System.ComponentModel.ISupportInitialize)dgAttendanceRecord).EndInit();
			ResumeLayout(false);
		}

		#endregion
		private Sunny.UI.UIButton btnQueryFromRFID;
		private Sunny.UI.UIDataGridView dgAttendanceRecord;
		private Sunny.UI.UIButton btnQueryFromServer;
		private Sunny.UI.UIDatePicker uiDatePicker1;
		private Sunny.UI.UILabel lblSelectDate;
		private Sunny.UI.UILabel lblPrompt1;
		private Sunny.UI.UILabel lblPrompt3;
		private Sunny.UI.UILabel lblPrompt2;
		private System.Windows.Forms.Timer timer1;
	}
}