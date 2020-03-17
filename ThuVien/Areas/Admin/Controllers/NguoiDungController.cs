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
    public class NguoiDungController : BaseController
    {
        // GET: Admin/SinhVien
        public ActionResult Index(string TimKiem, int Trang = 1, int KTTrang = 10)
        {
            var dao = new NguoiDungDAO();
            var DSNguoiDung = dao.LayDSTheoTrang(TimKiem, Trang, KTTrang);
            ViewBag.TimKiem = TimKiem;
            return View(DSNguoiDung);
        }

        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(NguoiDung nguoidung)
        {
            if (ModelState.IsValid)
            {
                var dao = new NguoiDungDAO();

                if (nguoidung.MatKhau == null)
                {
                    nguoidung.MatKhau = Encryptor.MD5Hash(nguoidung.TaiKhoan);
                }
                else nguoidung.MatKhau = Encryptor.MD5Hash(nguoidung.MatKhau);

                var KetQua = dao.ThemMoi(nguoidung);

                if(KetQua > 0)
                {
                    DatThongBao("Thêm mới người dùng thành công!", LoaiThongBao.ThanhCong);
                    return RedirectToAction("Index");
                }
                else
                {
                    DatThongBao("Thêm mới người dùng không thành công!", LoaiThongBao.Loi);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult CapNhat(string id)
        {
            var dao = new NguoiDungDAO();
            var ThongTinNguoiDung = dao.TimTheoTenTK(id);

            if (ThongTinNguoiDung != null)
            {
                ThongTinNguoiDung.MatKhau = null;
                return View(ThongTinNguoiDung);
            }
            return Redirect("/404");
        }

        [HttpPost]
        public ActionResult CapNhat(NguoiDung nguoidung)
        {
            if (ModelState.IsValid)
            {
                var dao = new NguoiDungDAO();

                if(nguoidung.MatKhau == null)
                {
                    nguoidung.MatKhau = dao.TimTheoTenTK(nguoidung.TaiKhoan).MatKhau;
                }
                else nguoidung.MatKhau = Encryptor.MD5Hash(nguoidung.MatKhau); //Mã hóa

                var KetQua = dao.CapNhat(nguoidung);
                if(KetQua > 0)
                {
                    DatThongBao("Cập nhật thông tin người dùng thành công!", LoaiThongBao.ThanhCong);
                    return RedirectToAction("Index");
                }
                else
                {
                    DatThongBao("Cập nhật thông tin người dùng không thành công!", LoaiThongBao.Loi);
                }
            }
            return View();
        }

        public ActionResult Xoa(string id)
        {
            var dao = new NguoiDungDAO();
            var NguoiDung = dao.TimTheoTenTK(id);

            if(NguoiDung != null)
            {
                var KetQua = dao.Xoa(id);
                if(KetQua > 0)
                {
                    DatThongBao("Xóa người dùng thành công!", LoaiThongBao.ThanhCong);
                }
                else
                {
                    DatThongBao("Xóa người dùng không thành công!", LoaiThongBao.Loi);
                }
                return RedirectToAction("Index");
            }
            return Redirect("/404");
        }

        [HttpPost]
        public JsonResult ThayDoiTrangThai(string id)
        {
            var dao = new NguoiDungDAO();
            var KetQua = dao.ThayDoiTrangThai(id);
            return Json(new { 
                TrangThai = KetQua
            });
        }
    }
}