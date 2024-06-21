using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;  //必须要添加该引用
using System.Diagnostics;
using AttendanceSystemUI.Entities;
using System.Configuration;

namespace AttendanceSystemUI.Clients
{

    public class RFIDReaderClient
    {
        private static readonly uint portNo = uint.Parse(ConfigurationManager.AppSettings["COMPortNo"].ToString());

		public RFIDReaderClient()
        {
            ResultStatus status = (ResultStatus)RC_initialize(portNo);
            if(status != ResultStatus.SUCCESS) {
                MessageBox.Show(status.resultStatusToString());
				System.Environment.Exit(0);   
			}
        }

        ~RFIDReaderClient()
        {
			ResultStatus status = (ResultStatus)RC_close();
			if (status != ResultStatus.SUCCESS) {
				MessageBox.Show(status.resultStatusToString());
				System.Environment.Exit(0);
			}
        }

        public ResultStatus readCardInfo(out CardInfo cardInfo)
        {
            cardInfo = new CardInfo();
            return (ResultStatus)RC_readCardInfo(ref cardInfo);
        }

        public ResultStatus readUserInfo(out UserInfo userInfo)
        {
            userInfo = new UserInfo();
            return (ResultStatus)RC_readUserInfo(ref userInfo);
        }

        public ResultStatus writeUserInfo(ref UserInfo userInfo)
        {
            return (ResultStatus)RC_writeUserInfo(ref userInfo);
        }

        public ResultStatus writeMonthlyRecord(ref MonthlyRecord record) {
            return (ResultStatus)RC_writeMonthlyRecord(ref record);
		}

		public ResultStatus readMonthlyRecord(out MonthlyRecord record) {
            record = new MonthlyRecord();
			return (ResultStatus)RC_readMonthlyRecord(ref record);
		}

		[DllImport("RFIDReaderClient.dll")]
        private static extern int RC_initialize(uint portNo);

        [DllImport("RFIDReaderClient.dll")]
        private static extern int RC_readCardInfo(ref CardInfo pCardInfo);

        [DllImport("RFIDReaderClient.dll")]
        private static extern int RC_readUserInfo(ref UserInfo pUserInfo);

        [DllImport("RFIDReaderClient.dll")]
        private static extern int RC_readUserInfoW(ref UserInfo pUserInfoW);


        [DllImport("RFIDReaderClient.dll")]
        private static extern int RC_writeUserInfo(ref UserInfo pUserInfo);

		[DllImport("RFIDReaderClient.dll")]
		private static extern int RC_writeMonthlyRecord(ref MonthlyRecord pMonthlyRecord);

		[DllImport("RFIDReaderClient.dll")]
		private static extern int RC_readMonthlyRecord(ref MonthlyRecord pMonthlyRecord);

		[DllImport("RFIDReaderClient.dll")]
        private static extern int RC_close();


    }
}
