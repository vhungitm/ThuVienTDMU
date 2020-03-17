using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;

namespace ThuVien.Areas.Admin.Controllers
{
    public class LoaiSachController : BaseController
    {
        // GET: Admin/LoaiSach
        public ActionResult Index(string TimKiem, int Trang = 1, int KTTrang = 10)
        {
            LoaiSachDAO dao = new LoaiSachDAO();
            var DSLoaiSach = dao.LayDSTheoTrang(TimKiem, Trang, KTTrang);
            ViewBag.TimKiem = TimKiem;
            return View(DSLoaiSach);
        }

        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(LoaiSach loaisach)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoaiSachDAO();
                var KetQua = dao.ThemMoi(loaisach);
                if (KetQua > 0)
                {
                    DatThongBao("Thêm mới thể loại sách thành công!", LoaiThongBao.ThanhCong);
                    return RedirectToAction("Index", "LoaiSach");
                }
                else
                {
                    DatThongBao("Thêm mới thể loại sách không thành công!", LoaiThongBao.Loi);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult CapNhat(int id)
        {
            var dao = new LoaiSachDAO();
            var KetQua = dao.TimTheoMaLoai(id);
            if (KetQua != null)
            {
                return View(KetQua);
            }
            else return Redirect("/404");

        }

        [HttpPost]
        public ActionResult CapNhat(LoaiSach loaisach)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoaiSachDAO();
                var KetQua = dao.CapNhat(loaisach);

                if (KetQua > 0)
                {
                    DatThongBao("Cập nhật thông tin thể loại sách thành công!", LoaiThongBao.ThanhCong);
                    return RedirectToAction("Index", "LoaiSach");
                }
                else
                {
                    DatThongBao("Cập nhật thông tin thể loại sách không thành công!", LoaiThongBao.Loi);
                }
            }
            return View();
        }

        public ActionResult Xoa(int id)
        {
            var dao = new LoaiSachDAO();
            var ThongTin = dao.TimTheoMaLoai(id);

            if (ThongTin != null)
            {
                var KetQua = dao.Xoa(id);

                if (KetQua > 0)
                {
                    DatThongBao("Xóa thể loại sách thành công!", LoaiThongBao.ThanhCong);
                }
                else
                {
                    DatThongBao("Xóa thể loại sách không thành công!", LoaiThongBao.Loi);
                }
                RedirectToAction("Index");
            }
            return Redirect("/404");
        }
    }
}