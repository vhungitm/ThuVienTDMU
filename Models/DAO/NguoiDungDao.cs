using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class NguoiDungDAO
    {
        DBContext db = null;
        public NguoiDungDAO()
        {
            db = new DBContext();
        }

        public NguoiDung TimTheoTenTK(string TaiKhoan)
        {
            try
            {
                var Paramet = new SqlParameter("@TaiKhoan", TaiKhoan);
                return db.Database.SqlQuery<NguoiDung>("NguoiDung_TimTheoTenTK @TaiKhoan", Paramet).SingleOrDefault();
            } catch (Exception) { return null; }
        }
        public int DangNhap(string TaiKhoan, string MatKhau, bool isAdmin = false)
        {
            try
            {
                if (isAdmin == true)
                {
                    var Paramet = new SqlParameter[]
                    {
                    new SqlParameter("@TaiKhoan", TaiKhoan),
                    new SqlParameter("@MatKhau", MatKhau)
                    };
                    return db.Database.SqlQuery<int>("Admin_DangNhap @TaiKhoan, @MatKhau", Paramet).SingleOrDefault();
                }
                else
                {
                    return 1;
                }
            } catch (Exception) { return 0; }
        }

        public IPagedList<NguoiDung> LayDSTheoTrang(string TuKhoa, int Trang, int KTTrang)
        {
            try
            {
                if (!string.IsNullOrEmpty(TuKhoa))
                {
                    var Paramet = new SqlParameter("@TuKhoa", TuKhoa);
                    return db.Database.SqlQuery<NguoiDung>("NguoiDung_TimKiem @TuKhoa", Paramet).ToList().ToPagedList(Trang, KTTrang);
                }
                return db.Database.SqlQuery<NguoiDung>("NguoiDung_LayTatCa").ToList().ToPagedList(Trang, KTTrang);
            } catch (Exception) { return null; }
        }

        public int ThemMoi(NguoiDung nguoidung)
        {
            try
            {
                var Paramet = new SqlParameter[]
                {
                    new SqlParameter("@TaiKhoan", nguoidung.TaiKhoan),
                    new SqlParameter("@MatKhau", nguoidung.MatKhau),
                    new SqlParameter("@Quyen", nguoidung.Quyen),
                    new SqlParameter("@TrangThai", nguoidung.TrangThai)
                };

                return db.Database.ExecuteSqlCommand("NguoiDung_ThemMoi @TaiKhoan, @MatKhau, @Quyen, @TrangThai", Paramet);
            }
            catch (Exception) { return 0; }
        }

        public int CapNhat(NguoiDung nguoidung)
        {
            try
            {
                var Paramet = new SqlParameter[]
                {
                    new SqlParameter("@TaiKhoan", nguoidung.TaiKhoan),
                    new SqlParameter("@MatKhau", nguoidung.MatKhau),
                    new SqlParameter("@Quyen", nguoidung.Quyen),
                    new SqlParameter("@TrangThai", nguoidung.TrangThai)
                };
                return db.Database.ExecuteSqlCommand("NguoiDung_CapNhat @TaiKhoan, @MatKhau, @TrangThai", Paramet);
            }
            catch (Exception) { return 0; }
        }

        public int Xoa(string TaiKhoan)
        {
            try
            {
                var Paramet = new SqlParameter("@TaiKhoan", TaiKhoan);
                return db.Database.ExecuteSqlCommand("NguoiDung_Xoa @TaiKhoan", Paramet);
            }
            catch (Exception) { return 0; }
        }

        public int ThayDoiTrangThai(string TaiKhoan)
        {
            try
            {
                var Paramet = new SqlParameter("@TaiKhoan", TaiKhoan);
                return db.Database.SqlQuery<int>("NguoiDung_ThayDoiTrangThai @TaiKhoan", Paramet).SingleOrDefault();
            }
            catch (Exception) { return -1; }
        }
    }
}
