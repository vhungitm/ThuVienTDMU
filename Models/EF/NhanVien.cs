namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            PhieuMuons = new HashSet<PhieuMuon>();
        }

        [Key]
        [StringLength(13, ErrorMessage = "Mã nhân viên không được vượt quá 13 ký tự")]
        public string MaNV { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập họ tên")]
        [StringLength(50, ErrorMessage = "Họ tên không được vượt quá 50 ký tự")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập giới tính")]
        [StringLength(5, ErrorMessage = "Giới tính không được vượt quá 5 ký tự")]
        public string GioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ")]
        [StringLength(150, ErrorMessage = "Địa chỉ không được vượt quá 50 ký tự")]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại")]
        [StringLength(13, ErrorMessage = "Số điện thoại không được vượt quá 13 ký tự")]
        public string SDT { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập email")]
        [StringLength(50, ErrorMessage = "Email không được vượt quá 50 ký tự")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập chức vụ")]
        [StringLength(50, ErrorMessage = "Chức vụ không được vượt quá 50 ký tự")]
        public string ChucVu { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuMuon> PhieuMuons { get; set; }
    }
}
