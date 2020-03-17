using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using PagedList;
namespace Models.DAO
{
    public class LoaiSachDAO
    {
        DBContext db = null;
        public LoaiSachDAO()
        {
            db = new DBContext();
        }

        public LoaiSach TimTheoMaLoai(int MaLoai)
        {
            try
            {
                var Paramet = new SqlParameter("@MaLoai", MaLoai);
                return db.Database.SqlQuery<LoaiSach>("LoaiSach_TimTheoMaLoai @MaLoai", Paramet).SingleOrDefault();
            } catch (Exception) { return null; }
        }

        public List<LoaiSach> LayTatCa()
        {
            try
            {
                return db.Database.SqlQuery<LoaiSach>("LoaiSach_LayTatCa").ToList();
            }
            catch (Exception) { return null; }
        }

        public IPagedList<LoaiSach> LayDSTheoTrang(string TuKhoa, int Trang, int KTTrang)
        {
            try
            {
                if (!string.IsNullOrEmpty(TuKhoa))
                {
                    var Paramets = new SqlParameter("@TenLoai", TuKhoa);
                    return db.Database.SqlQuery<LoaiSach>("LoaiSach_TimTheoTen @TenLoai", Paramets).ToList().ToPagedList(Trang, KTTrang);
                }
                else
                {
                    return LayTatCa().ToPagedList(Trang, KTTrang);
                }
            } catch (Exception) { return null; }
        }

        public int ThemMoi(LoaiSach loaisach)
        {
            try
            {
                var Paramet = new SqlParameter("@TenLoai", loaisach.TenLoai);
                return db.Database.ExecuteSqlCommand("LoaiSach_ThemMoi @TenLoai", Paramet);
            } catch (Exception) { return 0; }
        }
        public int CapNhat(LoaiSach loaisach)
        {
            try
            {
                var Paramet = new SqlParameter[] {
                    new SqlParameter("@MaLoai", loaisach.MaLoai),
                    new SqlParameter("@TenLoai", loaisach.TenLoai)
                };
                return db.Database.ExecuteSqlCommand("LoaiSach_CapNhat @MaLoai, @TenLoai", Paramet);
            } catch (Exception) { return 0; }
        }

        public int Xoa(int MaLoai)
        {
            try
            {
                var Paramet = new SqlParameter("@MaLoai", MaLoai);
                return db.Database.ExecuteSqlCommand("LoaiSach_Xoa @MaLoai", Paramet);
            } catch (Exception) { return 0; }
        }
    }
}
