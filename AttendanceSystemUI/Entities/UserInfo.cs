﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystemUI.Entities
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct UserInfo
    {
		public uint userId;
		public uint cardId;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string name;
        public int role;
    };
}
