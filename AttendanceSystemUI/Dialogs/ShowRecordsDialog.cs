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

namespace AttendanceSystemUI.Dialogs
{
	public partial class ShowRecordsDialog : UIForm
	{
		public List<AttendanceRecord> dataList { get; set; }

		DataTable dataTable = new("Records");
		public ShowRecordsDialog(in List<AttendanceRecord> dataList) {
			InitializeComponent();
			this.dataList = dataList;

			dataTable.Columns.Add("记录号", typeof(int));
			dataTable.Columns.Add("员工ID", typeof(int));
			dataTable.Columns.Add("卡号", typeof(uint));
			dataTable.Columns.Add("姓名", typeof(string));
			dataTable.Columns.Add("角色", typeof(string));
			dataTable.Columns.Add("类型", typeof(string));
			dataTable.Columns.Add("记录时间", typeof(string));

			dgAttendanceRecord.DataSource = dataTable;
			dgAttendanceRecord.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgAttendanceRecord.AllowUserToAddRows = false;
			dgAttendanceRecord.ReadOnly = true;
			//不自动生成列
			dgAttendanceRecord.AutoGenerateColumns = false;

			//设置分页控件总数
			uiPagination1.TotalCount = dataList.Count;

			//设置分页控件每页数量
			uiPagination1.PageSize = 20;

			//设置统计绑定的表格
			uiDataGridViewFooter1.DataGridView = dgAttendanceRecord;
			uiPagination1.ActivePage = 1;
		}

		private void uiPagination1_PageChanged(object sender, object pagingSource, int pageIndex, int count) {
			//未连接数据库，通过模拟数据来实现
			//一般通过ORM的分页、或者SQL语句分页去取数据来填充dataTable
			//pageIndex：第几页，和界面对应，从1开始，取数据可能要用pageIndex - 1
			//count：单页数据量，也就是PageSize值

			dataTable.Rows.Clear();
			for (int i = (pageIndex - 1) * count; i < pageIndex * count; i++) {
				if (i >= dataList.Count) break;
				UserRole role = (UserRole)dataList[i].role;
				string time = dataList[i].recordTime.ToString("yyyy-MM-dd HH:mm:ss");
				GuestAction action = (GuestAction)dataList[i].type;
				dataTable.Rows.Add(dataList[i].recordId, dataList[i].staffId,
					dataList[i].cardId, dataList[i].name, role.userRoleToString(), action.guestActionToString(), time);
			}
			uiDataGridViewFooter1.Clear();
			uiDataGridViewFooter1["记录号"] = "合计：" + dataList.Count;
		}

		private void uiClose_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.Cancel;
		}
	}
}
