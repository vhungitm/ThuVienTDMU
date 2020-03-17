using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThuVien.Common
{
    [Serializable]
    public class TaiKhoanDangNhap
    {
        public string TaiKhoan { set; get; }
        public string HoTen { set; get; }

        public string Quyen { set; get; }
    }
}