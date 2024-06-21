namespace AttendanceSystemUI.Dialogs
{
	partial class ShowRecordsDialog
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
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			dgAttendanceRecord = new Sunny.UI.UIDataGridView();
			uiClose = new Sunny.UI.UIButton();
			uiPagination1 = new Sunny.UI.UIPagination();
			uiDataGridViewFooter1 = new Sunny.UI.UIDataGridViewFooter();
			((System.ComponentModel.ISupportInitialize)dgAttendanceRecord).BeginInit();
			SuspendLayout();
			// 
			// dgAttendanceRecord
			// 
			dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
			dgAttendanceRecord.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			dgAttendanceRecord.BackgroundColor = Color.White;
			dgAttendanceRecord.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
			dataGridViewCellStyle2.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle2.ForeColor = Color.White;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			dgAttendanceRecord.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			dgAttendanceRecord.ColumnHeadersHeight = 32;
			dgAttendanceRecord.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Window;
			dataGridViewCellStyle3.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
			dgAttendanceRecord.DefaultCellStyle = dataGridViewCellStyle3;
			dgAttendanceRecord.EnableHeadersVisualStyles = false;
			dgAttendanceRecord.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			dgAttendanceRecord.GridColor = Color.FromArgb(80, 160, 255);
			dgAttendanceRecord.Location = new Point(19, 50);
			dgAttendanceRecord.Name = "dgAttendanceRecord";
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
			dataGridViewCellStyle4.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
			dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
			dataGridViewCellStyle4.SelectionForeColor = Color.White;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
			dgAttendanceRecord.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			dataGridViewCellStyle5.BackColor = Color.White;
			dataGridViewCellStyle5.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			dgAttendanceRecord.RowsDefaultCellStyle = dataGridViewCellStyle5;
			dgAttendanceRecord.RowTemplate.Height = 25;
			dgAttendanceRecord.SelectedIndex = -1;
			dgAttendanceRecord.Size = new Size(662, 162);
			dgAttendanceRecord.StripeOddColor = Color.FromArgb(235, 243, 255);
			dgAttendanceRecord.TabIndex = 0;
			// 
			// uiClose
			// 
			uiClose.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			uiClose.Location = new Point(324, 289);
			uiClose.MinimumSize = new Size(1, 1);
			uiClose.Name = "uiClose";
			uiClose.Size = new Size(100, 35);
			uiClose.TabIndex = 1;
			uiClose.Text = "关闭";
			uiClose.TipsFont = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point);
			uiClose.Click += uiClose_Click;
			// 
			// uiPagination1
			// 
			uiPagination1.ButtonFillSelectedColor = Color.FromArgb(64, 128, 204);
			uiPagination1.ButtonStyleInherited = false;
			uiPagination1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			uiPagination1.Location = new Point(139, 246);
			uiPagination1.Margin = new Padding(4, 5, 4, 5);
			uiPagination1.MinimumSize = new Size(1, 1);
			uiPagination1.Name = "uiPagination1";
			uiPagination1.RectSides = ToolStripStatusLabelBorderSides.None;
			uiPagination1.ShowText = false;
			uiPagination1.Size = new Size(451, 35);
			uiPagination1.TabIndex = 2;
			uiPagination1.Text = "uiPagination1";
			uiPagination1.TextAlignment = ContentAlignment.MiddleCenter;
			uiPagination1.PageChanged += uiPagination1_PageChanged;
			// 
			// uiDataGridViewFooter1
			// 
			uiDataGridViewFooter1.DataGridView = null;
			uiDataGridViewFooter1.Font = new Font("宋体", 12F, FontStyle.Regular, GraphicsUnit.Point);
			uiDataGridViewFooter1.Location = new Point(19, 215);
			uiDataGridViewFooter1.MinimumSize = new Size(1, 1);
			uiDataGridViewFooter1.Name = "uiDataGridViewFooter1";
			uiDataGridViewFooter1.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
			uiDataGridViewFooter1.Size = new Size(662, 29);
			uiDataGridViewFooter1.TabIndex = 3;
			uiDataGridViewFooter1.Text = "uiDataGridViewFooter1";
			// 
			// ShowRecordsDialog
			// 
			AutoScaleMode = AutoScaleMode.None;
			ClientSize = new Size(712, 350);
			Controls.Add(uiDataGridViewFooter1);
			Controls.Add(uiPagination1);
			Controls.Add(uiClose);
			Controls.Add(dgAttendanceRecord);
			MaximizeBox = false;
			Name = "ShowRecordsDialog";
			ShowIcon = false;
			ShowInTaskbar = false;
			Text = "所有考勤记录";
			ZoomScaleRect = new Rectangle(15, 15, 800, 450);
			((System.ComponentModel.ISupportInitialize)dgAttendanceRecord).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Sunny.UI.UIDataGridView dgAttendanceRecord;
		private Sunny.UI.UIButton uiClose;
		private Sunny.UI.UIPagination uiPagination1;
		private Sunny.UI.UIDataGridViewFooter uiDataGridViewFooter1;
	}
}