using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using PagedList;

namespace Models.DAO
{
    public class NhanVienDAO
    {
        DBContext db = null;
        public NhanVienDAO()
        {
            db = new DBContext();
        }

        public NhanVien TimTheoMaNV(string MaNV)
        {
            try
            {
                var Paramet = new SqlParameter("@MaNV", MaNV);
                return db.Database.SqlQuery<NhanVien>("NhanVien_TimTheoMaNV @MaNV", Paramet).SingleOrDefault();
            } catch (Exception) { return null; }
        }

        public List<NhanVien> LayTatCa()
        {
            try
            {
                return db.Database.SqlQuery<NhanVien>("NhanVien_LayTatCa").ToList();
            }
            catch (Exception) { return null; }
        }

        public IPagedList<NhanVien> LayDSTheoTrang(string TuKhoa, int Trang, int KTTrang) {
            try
            {
                if (!string.IsNullOrEmpty(TuKhoa))
                {
                    var Paramet = new SqlParameter("@TuKhoa", TuKhoa);
                    return db.Database.SqlQuery<NhanVien>("NhanVien_TimKiem @TuKhoa", Paramet).ToList().ToPagedList(Trang, KTTrang);
                }
                return LayTatCa().ToPagedList(Trang, KTTrang);
            } catch (Exception) { return null; }
        }

        public int ThemMoi(NhanVien nhanvien)
        {
            try
            {
                var Paramet = new SqlParameter[]
                {
                    new SqlParameter("@MaNV", nhanvien.MaNV),
                    new SqlParameter("@HoTen", nhanvien.HoTen),
                    new SqlParameter("@GioiTinh", nhanvien.GioiTinh),
                    new SqlParameter("@NgaySinh", nhanvien.NgaySinh),
                    new SqlParameter("@DiaChi", nhanvien.DiaChi),
                    new SqlParameter("@SDT", nhanvien.SDT),
                    new SqlParameter("@Email", nhanvien.Email),
                    new SqlParameter("@ChucVu", nhanvien.ChucVu)
                };
                return db.Database.ExecuteSqlCommand("NhanVien_ThemMoi @MaNV, @HoTen, @GioiTinh, @NgaySinh, @DiaChi, @SDT, @Email, @ChucVu", Paramet);
            } catch (Exception) { return 0; }
        }

        public int CapNhat(NhanVien nhanvien)
        {
            try
            {
                var Paramet = new SqlParameter[]
                {
                    new SqlParameter("@MaNV", nhanvien.MaNV),
                    new SqlParameter("@HoTen", nhanvien.HoTen),
                    new SqlParameter("@GioiTinh", nhanvien.GioiTinh),
                    new SqlParameter("@NgaySinh", nhanvien.NgaySinh),
                    new SqlParameter("@DiaChi", nhanvien.DiaChi),
                    new SqlParameter("@SDT", nhanvien.SDT),
                    new SqlParameter("@Email", nhanvien.Email),
                    new SqlParameter("@ChucVu", nhanvien.ChucVu)
                };
                return db.Database.ExecuteSqlCommand("NhanVien_CapNhat @MaNV, @HoTen, @GioiTinh, @NgaySinh, @DiaChi, @SDT, @Email, @ChucVu", Paramet);
            }
            catch (Exception) { return 0; }
        }

        public int Xoa(string MaNV)
        {
            try
            {
                var Paramet = new SqlParameter("@MaNV", MaNV);
                return db.Database.ExecuteSqlCommand("NhanVien_Xoa @MaNV", Paramet);
            } catch (Exception) { return 0; }
        }
    }
}
