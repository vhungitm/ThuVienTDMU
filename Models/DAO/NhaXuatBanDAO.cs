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
    public class NhaXuatBanDAO
    {
        DBContext db = null;
        public NhaXuatBanDAO()
        {
            db = new DBContext();
        }

        public NhaXuatBan TimTheoMaNXB(int MaNXB)
        {
            try
            {
                var Paramet = new SqlParameter("@MaNXB", MaNXB);
                return db.Database.SqlQuery<NhaXuatBan>("NhaXuatBan_TimTheoMaNXB @MaNXB", Paramet).SingleOrDefault();
            }
            catch (Exception) { return null; }
        }
        public List<NhaXuatBan> LayTatCa()
        {
            try
            {
                return db.Database.SqlQuery<NhaXuatBan>("NhaXuatBan_LayTatCa").ToList();
            }
            catch (Exception) { return null; }
        }

        public IPagedList<NhaXuatBan> LayDSTheoTrang(string TuKhoa, int Trang, int KTTrang)
        {
            try
            {
                if (!string.IsNullOrEmpty(TuKhoa))
                {
                    var Paramet = new SqlParameter("@TuKhoa", TuKhoa);
                    return db.Database.SqlQuery<NhaXuatBan>("NhaXuatBan_TimKiem @TuKhoa", Paramet).ToList().ToPagedList(Trang, KTTrang);
                }
                return LayTatCa().ToPagedList(Trang, KTTrang);
            } catch (Exception) { return null; }
        }

        public int ThemMoi(NhaXuatBan nhaxuatban)
        {
            try
            {
                var Paramet = new SqlParameter[] {
                    new SqlParameter("@TenNXB", nhaxuatban.TenNXB),
                    new SqlParameter("@DiaChi", nhaxuatban.DiaChi),
                    new SqlParameter("@SDT", nhaxuatban.SDT)
                };
                return db.Database.ExecuteSqlCommand("NhaXuatBan_ThemMoi @TenNXB, @DiaChi, @SDT", Paramet);
            } catch (Exception) { return 0; }
        }

        public int CapNhat(NhaXuatBan nhaxuatban)
        {
            try
            {
                var Paramet = new SqlParameter[] {
                    new SqlParameter("@MaNXB", nhaxuatban.MaNXB),
                    new SqlParameter("@TenNXB", nhaxuatban.TenNXB),
                    new SqlParameter("@DiaChi", nhaxuatban.DiaChi),
                    new SqlParameter("@SDT", nhaxuatban.SDT)
                };
                return db.Database.ExecuteSqlCommand("NhaXuatBan_CapNhat @MaNXB, @TenNXB, @DiaChi, @SDT", Paramet);
            }
            catch (Exception) { return 0; }
        }

        public int Xoa(int MaNXB)
        {
            try
            {
                var Paramet = new SqlParameter("@MaNXB", MaNXB);
                return db.Database.ExecuteSqlCommand("NhaXuatBan_Xoa @MaNXB", Paramet);
            } catch (Exception) { return 0; }
        }
    }
}
