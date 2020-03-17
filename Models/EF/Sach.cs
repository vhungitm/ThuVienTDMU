namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            PhieuMuons = new HashSet<PhieuMuon>();
        }

        [Key]
        public long MaSach { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập tên sách")]
        [StringLength(50, ErrorMessage = "Tên sách không được vượt quá 50 ký tự")]
        public string TenSach { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ hình ảnh")]
        [StringLength(200, ErrorMessage = "Địa chỉ hình ảnh không được vượt quá 200 ký tự")]
        public string HinhAnh { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập tên tác giả")]
        [StringLength(100, ErrorMessage = "Tên tác giả không được vượt quá 100 ký tự")]
        public string TacGia { get; set; }

        public int MaLoai { get; set; }

        public int MaNXB { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập số lượng bản sao")]
        public int SoLuongBanSao { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập số trang")]
        public int SoTrang { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập kích thước")]
        [StringLength(10, ErrorMessage = "Chuỗi kích thước không được vượt quá 10 ký tự")]
        public string KichThuoc { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập trong lượng")]
        [StringLength(10, ErrorMessage = "Độ dài trọng lượng không được vượt quá 10 ký tự")]
        public string TrongLuong { get; set; }

        [Column(TypeName = "ntext")]
        public string ChiTiet { get; set; }

        public int NamXuatBan { get; set; }

        public virtual LoaiSach LoaiSach { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuMuon> PhieuMuons { get; set; }
    }
}
