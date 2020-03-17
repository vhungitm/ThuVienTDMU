using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;
using Models.ViewModel;
using PagedList;
using System.Data.SqlClient;

namespace Models.DAO
{
    public class SinhVienDAO
    {
        DBContext db = null;
        public SinhVienDAO()
        {
            db = new DBContext();
        }

        public SinhVien TimTheoMSSV(string MSSV)
        {
            try
            {
                var Paramet = new SqlParameter("@MSSV", MSSV);
                return db.Database.SqlQuery<SinhVien>("SinhVien_TimTheoMSSV @MSSV", Paramet).SingleOrDefault();
            } catch (Exception) { return null; }
        }
        public List<SinhVien> LayTatCa()
        {
            try
            {
                return db.Database.SqlQuery<SinhVien>("SinhVien_LayTatCa").ToList();
            }
            catch (Exception) { return null; }
        }
        public IPagedList<SinhVien> LayDSTheoTrang(string TuKhoa, int Trang, int KTTrang)
        {
            try
            {
                if (!string.IsNullOrEmpty(TuKhoa))
                {
                    var Paramet = new SqlParameter("@TuKhoa", TuKhoa);
                    return db.Database.SqlQuery<SinhVien>("SinhVien_TimKiem @TuKhoa", Paramet).ToList().ToPagedList(Trang, KTTrang);
                }
                else
                {
                    return LayTatCa().ToPagedList(Trang, KTTrang);
                }
            }
            catch (Exception) { return null; }
        }

        public int ThemMoi(SinhVien sinhvien)
        {
            try
            {
                var Paramet = new SqlParameter[]
                {
                    new SqlParameter("@MSSV", sinhvien.MSSV),
                    new SqlParameter("@HoTen", sinhvien.HoTen),
                    new SqlParameter("@GioiTinh", sinhvien.GioiTinh),
                    new SqlParameter("@NgaySinh", sinhvien.NgaySinh),
                    new SqlParameter("@DiaChi", sinhvien.DiaChi),
                    new SqlParameter("@SDT", sinhvien.SDT),
                    new SqlParameter("@Email", sinhvien.Email),
                    new SqlParameter("@Lop", sinhvien.Lop),
                    new SqlParameter("@ChuyenNganh", sinhvien.ChuyenNganh),
                    new SqlParameter("@Khoa", sinhvien.Khoa)
                };
                return db.Database.ExecuteSqlCommand("SinhVien_ThemMoi @MSSV, @HoTen, @GioiTinh, @NgaySinh, @DiaChi, @SDT, @Email, @Lop, @ChuyenNganh, @Khoa", Paramet);
            }
            catch (Exception) { return 0; }
        }

        public int CapNhat(SinhVien sinhvien)
        {
            try
            {
                var Paramet = new SqlParameter[]
                {
                    new SqlParameter("@MSSV", sinhvien.MSSV),
                    new SqlParameter("@HoTen", sinhvien.HoTen),
                    new SqlParameter("@GioiTinh", sinhvien.GioiTinh),
                    new SqlParameter("@NgaySinh", sinhvien.NgaySinh),
                    new SqlParameter("@DiaChi", sinhvien.DiaChi),
                    new SqlParameter("@SDT", sinhvien.SDT),
                    new SqlParameter("@Email", sinhvien.Email),
                    new SqlParameter("@Lop", sinhvien.Lop),
                    new SqlParameter("@ChuyenNganh", sinhvien.ChuyenNganh),
                    new SqlParameter("@Khoa", sinhvien.Khoa)
                };
                return db.Database.ExecuteSqlCommand("SinhVien_CapNhat @MSSV, @HoTen, @GioiTinh, @NgaySinh, @DiaChi, @SDT, @Email, @Lop, @ChuyenNganh, @Khoa", Paramet);
            }
            catch (Exception) { return 0; }
        }

        public int Xoa(string MSSV)
        {
            try
            {
                var Paramet = new SqlParameter("@MSSV", MSSV);
                return db.Database.ExecuteSqlCommand("SinhVien_Xoa @MSSV", Paramet);
            } catch (Exception) { return 0; }
        }
    }
}
