using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class PhieuMuonViewModel
    {
        public long MaPM { set; get; }
        public string TenSV { set; get; }
        public string TenNV { set; get; }
        public string TenSach { set; get; }
        public DateTime NgayMuon { set; get; }
        public DateTime NgayTra { set; get; }
        public bool TrangThai { set; get; }
    }
}
