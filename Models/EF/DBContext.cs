namespace Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<LoaiSach> LoaiSaches { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public virtual DbSet<PhieuMuon> PhieuMuons { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiSach>()
                .HasMany(e => e.Saches)
                .WithRequired(e => e.LoaiSach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Quyen)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .HasOptional(e => e.NhanVien)
                .WithRequired(e => e.NguoiDung);

            modelBuilder.Entity<NguoiDung>()
                .HasOptional(e => e.SinhVien)
                .WithRequired(e => e.NguoiDung);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.PhieuMuons)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaXuatBan>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NhaXuatBan>()
                .HasMany(e => e.Saches)
                .WithRequired(e => e.NhaXuatBan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuMuon>()
                .Property(e => e.MSSV)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuMuon>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.KichThuoc)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .Property(e => e.TrongLuong)
                .IsUnicode(false);

            modelBuilder.Entity<Sach>()
                .HasMany(e => e.PhieuMuons)
                .WithRequired(e => e.Sach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.MSSV)
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.Lop)
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .HasMany(e => e.PhieuMuons)
                .WithRequired(e => e.SinhVien)
                .WillCascadeOnDelete(false);
        }
    }
}
