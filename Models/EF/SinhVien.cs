namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SinhVien()
        {
            PhieuMuons = new HashSet<PhieuMuon>();
        }

        [Key]
        [StringLength(13, ErrorMessage = "Mã số sinh viên không được vượt quá 13 ký tự")]
        public string MSSV { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập họ tên")]
        [StringLength(50, ErrorMessage = "Họ tên không được vượt quá 50 ký tự")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập giới tính")]
        [StringLength(5, ErrorMessage = "Giới tính không được vượt quá 5 ký tự")]
        public string GioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ")]
        [StringLength(150, ErrorMessage = "Địa chỉ không được vượt quá 150 ký tự")]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại")]
        [StringLength(13, ErrorMessage = "Số điện thoại không được vượt quá 13 ký tự")]
        public string SDT { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập email")]
        [StringLength(50, ErrorMessage = "Địa chỉ email không được vượt quá 50 ký tự")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập lớp")]
        [StringLength(7, ErrorMessage = "Tên lớp không được vượt quá 7 ký tự")]
        public string Lop { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập chuyên ngành")]
        [StringLength(50, ErrorMessage = "Tên chuyên ngành không được vượt quá 50 ký tự")]
        public string ChuyenNganh { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập khoa")]
        [StringLength(50, ErrorMessage = "Tên khoa không được vượt quá 50 ký tự")]
        public string Khoa { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuMuon> PhieuMuons { get; set; }
    }
}
