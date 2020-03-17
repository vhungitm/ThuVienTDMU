namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuMuon")]
    public partial class PhieuMuon
    {
        [Key]
        public long MaPM { get; set; }

        [Required]
        [StringLength(13)]
        public string MSSV { get; set; }

        [Required]
        [StringLength(13)]
        public string MaNV { get; set; }

        public long MaSach { get; set; }

        public DateTime NgayMuon { get; set; }

        public DateTime? NgayTra { get; set; }

        public bool TrangThai { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual Sach Sach { get; set; }

        public virtual SinhVien SinhVien { get; set; }
    }
}
