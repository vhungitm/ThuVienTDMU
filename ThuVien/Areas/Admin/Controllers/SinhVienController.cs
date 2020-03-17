using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using ThuVien.Common;

namespace ThuVien.Areas.Admin.Controllers
{
    public class SinhVienController : BaseController
    {
        // GET: Admin/SinhVien
        public ActionResult Index(string TimKiem, int Trang = 1, int KTTrang = 10)
        {
            var dao = new SinhVienDAO();
            var DSSinhVien = dao.LayDSTheoTrang(TimKiem, Trang, KTTrang);
            ViewBag.TimKiem = TimKiem;
            return View(DSSinhVien);
        }

        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(SinhVien sinhvien)
        {
            if (ModelState.IsValid)
            {
                var dao = new SinhVienDAO();

                var KetQua = dao.ThemMoi(sinhvien);

                if(KetQua > 0)
                {
                    DatThongBao("Thêm mới sinh viên thành công!", LoaiThongBao.ThanhCong);
                    return RedirectToAction("Index");
                }
                else
                {
                    DatThongBao("Thêm mới sinh viên không thành công!", LoaiThongBao.Loi);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult CapNhat(string id)
        {
            var dao = new SinhVienDAO();
            var ThongTinSV = dao.TimTheoMSSV(id);

            if (ThongTinSV != null)
            {
                return View(ThongTinSV);
            }
            return Redirect("/404");
        }

        [HttpPost]
        public ActionResult CapNhat(SinhVien sinhvien)
        {
            if (ModelState.IsValid)
            {
                var dao = new SinhVienDAO();

                var KetQua = dao.CapNhat(sinhvien);
                if(KetQua > 0)
                {
                    DatThongBao("Cập nhật thông tin sinh viên thành công!", LoaiThongBao.ThanhCong);
                    return RedirectToAction("Index");
                }
                else
                {
                    DatThongBao("Cập nhật thông tin sinh viên không thành công!", LoaiThongBao.Loi);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Xoa(string id)
        {
            var dao = new SinhVienDAO();
            var SinhVien = dao.TimTheoMSSV(id);

            if(SinhVien != null)
            {
                var KetQua = dao.Xoa(id);
                if(KetQua > 0)
                {
                    DatThongBao("Xóa sinh viên thành công!", LoaiThongBao.ThanhCong);
                }
                else
                {
                    DatThongBao("Xóa sinh viên không thành công!", LoaiThongBao.Loi);
                }
                return RedirectToAction("Index");
            }
            return Redirect("/404");
        }
    }
}