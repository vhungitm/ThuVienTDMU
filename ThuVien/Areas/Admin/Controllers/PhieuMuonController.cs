using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.ViewModel;

namespace ThuVien.Areas.Admin.Controllers
{
    public class PhieuMuonController : BaseController
    {
        // GET: Admin/PhieuMuon
        public ActionResult Index(string TimKiem, int Trang = 1, int KTTrang = 10)
        {
            var dao = new PhieuMuonDAO();
            var DSPhieuMuon = dao.LayDSTheoTrang(TimKiem, Trang, KTTrang);
            ViewBag.TimKiem = TimKiem;
            return View(DSPhieuMuon);
        }

        [HttpPost]
        public JsonResult ThayDoiTrangThai(long id)
        {
            var dao = new PhieuMuonDAO();
            var KetQua = dao.ThayDoiTrangThai(id);

            return Json(new
            {
                TrangThai = KetQua
            });
        }
    }
}