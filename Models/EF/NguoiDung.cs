namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [Key]
        [StringLength(13, ErrorMessage = "Tên tài khoản không được vượt quá 13 ký tự")]
        public string TaiKhoan { get; set; }

        [StringLength(50, ErrorMessage = "Mật khẩu không được vượt quá 50 ký tự")]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập quyền")]
        [StringLength(20, ErrorMessage = "Quyền không được vượt quá 20 ký tự")]
        public string Quyen { get; set; }

        public bool TrangThai { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual SinhVien SinhVien { get; set; }
    }
}
