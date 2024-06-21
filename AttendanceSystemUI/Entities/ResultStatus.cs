using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystemUI.Entities
{
    public enum ResultStatus {
        SUCCESS = 0,
        READER_FAIL = 0x01,
        READER_NO_CARD = 0x02,
        READER_BAD_TRANSMISSION = 0x03,
        READER_OPENPORT_FAILED = 0x04,
        READER_TIMEOUT = 0x05,
		SERVER_RESPONSE_TIMEOUT = 10001,
		SERVER_ERROR = 10002,
        NO_PERMISSION = 10008,
        NOT_REGISTERED = 10012,
        INTEGRITY_ERROR = 10013,
        DUPLICATE_LOGIN = 10014,
        DUPLICATE_LOGOUT = 10015,
        NO_CONTENT = 10016,
        UNDEFINED_ERROR = -1
    }
}
