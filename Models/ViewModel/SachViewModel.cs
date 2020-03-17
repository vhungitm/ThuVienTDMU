using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModel
{
    public class SachViewModel
    {
        [Key]
        public long MaSach { get; set; }
        public string TenSach { get; set; }
        public string HinhAnh { get; set; }
        public string TacGia { get; set; }
        public string LoaiSach { get; set; }
        public string NhaXuatBan { get; set; }
        public int SoLuongBanSao { get; set; }
        public int SoTrang { get; set; }
        public string KichThuoc { get; set; }
        public string TrongLuong { get; set; }
        public string ChiTiet { get; set; }
        public int NamXuatBan { get; set; }
    }
}
