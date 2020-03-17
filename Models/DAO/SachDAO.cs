using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;
using Models.ViewModel;

namespace Models.DAO
{
    public class SachDAO
    {
        DBContext db = null;
        public SachDAO()
        {
            db = new DBContext();
        }

        public Sach TimTheoMaSach(long MaSach)
        {
            try
            {
                var Paramet = new SqlParameter("@MaSach", MaSach);
                return db.Database.SqlQuery<Sach>("Sach_TimTheoMaSach @MaSach", Paramet).SingleOrDefault();
            } catch (Exception) { return null; }
        }

        public List<SachViewModel> LayTatCa()
        {
            try
            {
                return db.Database.SqlQuery<SachViewModel>("Sach_LayTatCa").ToList();
            }
            catch (Exception) { return null; }
        }

        public List<SachViewModel> LayTheoLoaiSach(int MaLoai)
        {
            try
            {
                var Paramet = new SqlParameter("@MaLoai", MaLoai);
                return db.Database.SqlQuery<SachViewModel>("Sach_LayTheoLoaiSach @MaLoai", Paramet).ToList();
            } catch (Exception) { return null; }
        }

        public SachViewModel LayTheoMaSach(long MaSach)
        {
            try
            {
                var Paramet = new SqlParameter("@MaSach", MaSach);
                return db.Database.SqlQuery<SachViewModel>("Sach_LayTheoMaSach @MaSach", Paramet).SingleOrDefault() ;
            }
            catch (Exception) { return null; }
        }
        public IEnumerable<SachViewModel> LayDSTheoTrang(string TuKhoa, int Trang, int KTTrang)
        {
            try
            {
                if (!string.IsNullOrEmpty(TuKhoa))
                {
                    var Paramet = new SqlParameter("@TuKhoa", TuKhoa);
                    return db.Database.SqlQuery<SachViewModel>("Sach_TimKiem @TuKhoa", Paramet).ToList().ToPagedList(Trang, KTTrang);
                }
                return LayTatCa().ToPagedList(Trang, KTTrang);
            } catch (Exception) { return null; }
        }

        public int ThemMoi(Sach sach)
        {
            try
            {
                var Paramet = new SqlParameter[]
                {
                    new SqlParameter("@TenSach", sach.TenSach),
                    new SqlParameter("@HinhAnh", sach.HinhAnh),
                    new SqlParameter("@TacGia", sach.TacGia),
                    new SqlParameter("@MaLoai", sach.MaLoai),
                    new SqlParameter("@MaNXB", sach.MaNXB),
                    new SqlParameter("@SoLuongBanSao", sach.SoLuongBanSao),
                    new SqlParameter("@SoTrang", sach.SoTrang),
                    new SqlParameter("@KichThuoc", sach.KichThuoc),
                    new SqlParameter("@TrongLuong", sach.TrongLuong),
                    new SqlParameter("@ChiTiet", sach.ChiTiet ?? (object)DBNull.Value),
                    new SqlParameter("@NamXuatBan", sach.NamXuatBan)
                };
                return db.Database.ExecuteSqlCommand("Sach_ThemMoi @TenSach, @HinhAnh, @TacGia, @MaLoai, @MaNXB, @SoLuongBanSao, @SoTrang, @KichThuoc, @TrongLuong, @ChiTiet, @NamXuatBan", Paramet);
            } catch (Exception) { return 0; }
        }

        public int CapNhat(Sach sach)
        {
            try
            {
                var Paramet = new SqlParameter[]
                {
                    new SqlParameter("@MaSach", sach.MaSach),
                    new SqlParameter("@TenSach", sach.TenSach),
                    new SqlParameter("@HinhAnh", sach.HinhAnh),
                    new SqlParameter("@TacGia", sach.TacGia),
                    new SqlParameter("@MaLoai", sach.MaLoai),
                    new SqlParameter("@MaNXB", sach.MaNXB),
                    new SqlParameter("@SoLuongBanSao", sach.SoLuongBanSao),
                    new SqlParameter("@SoTrang", sach.SoTrang),
                    new SqlParameter("@KichThuoc", sach.KichThuoc),
                    new SqlParameter("@TrongLuong", sach.TrongLuong),
                    new SqlParameter("@ChiTiet", sach.ChiTiet ?? (object)DBNull.Value),
                    new SqlParameter("@NamXuatBan", sach.NamXuatBan)
                };
                return db.Database.ExecuteSqlCommand("Sach_CapNhat @MaSach, @TenSach, @HinhAnh, @TacGia, @MaLoai, @MaNXB, @SoLuongBanSao, @SoTrang, @KichThuoc, @TrongLuong, @ChiTiet, @NamXuatBan", Paramet);
            } catch (Exception) { return 0; }
        }

        public int Xoa(long MaSach)
        {
            try
            {
                var Paramet = new SqlParameter("@MaSach", MaSach);
                return db.Database.ExecuteSqlCommand("Sach_Xoa @MaSach", Paramet);
            } catch (Exception) { return 0; }
        }
    }
}
