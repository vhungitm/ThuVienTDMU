using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ViewModel;
using Models.EF;
using PagedList;
using System.Data.SqlClient;

namespace Models.DAO
{
    public class PhieuMuonDAO
    {
        DBContext db = null;
        public PhieuMuonDAO()
        {
            db = new DBContext();
        }

        public IPagedList<PhieuMuonViewModel> LayDSTheoTrang(string TuKhoa, int Trang, int KTTrang)
        {
            try
            {
                if (!string.IsNullOrEmpty(TuKhoa))
                {
                    var Paramet = new SqlParameter("@TuKhoa", TuKhoa);
                    return db.Database.SqlQuery<PhieuMuonViewModel>("PhieuMuon_TimKiem @TuKhoa", Paramet).ToList().ToPagedList(Trang, KTTrang);
                }
                return db.Database.SqlQuery<PhieuMuonViewModel>("PhieuMuon_LayTatCa").ToPagedList(Trang, KTTrang);
            }
            catch (Exception) { return null; }
        }

        public int ThayDoiTrangThai(long MaPM)
        {
            try
            {
                var Paramet = new SqlParameter("@MaPM", MaPM);
                return db.Database.SqlQuery<int>("PhieuMuon_ThayDoiTrangThai @MaPM", Paramet).SingleOrDefault();
            }
            catch (Exception) { return -1; }
        }
    }
}
