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
    public class NhanVienController : BaseController
    {
        // GET: Admin/NhanVien
        public ActionResult Index(string TimKiem, int Trang = 1, int KTTrang = 10)
        {
            var dao = new NhanVienDAO();
            var DSNhanVien = dao.LayDSTheoTrang(TimKiem, Trang, KTTrang);
            ViewBag.TimKiem = TimKiem;
            return View(DSNhanVien);
        }

        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(NhanVien nhanvien)
        {
            if (ModelState.IsValid)
            {
                var dao = new NhanVienDAO();

                var KetQua = dao.ThemMoi(nhanvien);

                if(KetQua > 0)
                {
                    DatThongBao("Thêm mới nhân viên thành công!", LoaiThongBao.ThanhCong);
                    return RedirectToAction("Index");
                }
                else
                {
                    DatThongBao("Thêm mới nhân viên không thành công!", LoaiThongBao.Loi);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult CapNhat(string id)
        {
            var dao = new NhanVienDAO();
            var ThongTinNhanVien = dao.TimTheoMaNV(id);

            if (ThongTinNhanVien != null)
            {
                return View(ThongTinNhanVien);
            }
            return Redirect("/404");
        }

        [HttpPost]
        public ActionResult CapNhat(NhanVien nhanvien)
        {
            if (ModelState.IsValid)
            {
                var dao = new NhanVienDAO();

                var KetQua = dao.CapNhat(nhanvien);
                if(KetQua > 0)
                {
                    DatThongBao("Cập nhật thông tin nhân viên thành công!", LoaiThongBao.ThanhCong);
                    return RedirectToAction("Index");
                }
                else
                {
                    DatThongBao("Cập nhật thông tin nhân viên không thành công!", LoaiThongBao.Loi);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Xoa(string id)
        {
            var dao = new NhanVienDAO();
            var NhanVien = dao.TimTheoMaNV(id);

            if(NhanVien != null)
            {
                var KetQua = dao.Xoa(id);
                if(KetQua > 0)
                {
                    DatThongBao("Xóa nhân viên thành công!", LoaiThongBao.ThanhCong);
                }
                else
                {
                    DatThongBao("Xóa nhân viên không thành công!", LoaiThongBao.Loi);
                }
                return RedirectToAction("Index");
            }
            return Redirect("/404");
        }
    }
}