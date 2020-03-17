using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThuVien.Areas.Admin.Models;
using Models.DAO;
using Models.EF;
using ThuVien.Common;

namespace ThuVien.Areas.Admin.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: Admin/DangNhap
        public ActionResult Index()
        {
            if (Session[CommonConstants.NGUOIDUNG_SESSION] == null)
                return View();
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult DangNhap(DangNhapModel model)
        {
            if (ModelState.IsValid)
            {
                NguoiDungDAO dao = new NguoiDungDAO();
                var KetQua = dao.DangNhap(model.TaiKhoan, Encryptor.MD5Hash(model.MatKhau), true);
                if ( KetQua == 1)
                {
                    var Quyen = new NguoiDungDAO().TimTheoTenTK(model.TaiKhoan).Quyen;
                    var HoTen = new NhanVienDAO().TimTheoMaNV(model.TaiKhoan).HoTen;
                    var TKDangNhap = new TaiKhoanDangNhap();
                    
                    TKDangNhap.TaiKhoan = model.TaiKhoan;
                    TKDangNhap.HoTen = HoTen;
                    TKDangNhap.Quyen = Quyen;

                    Session.Add(Common.CommonConstants.NGUOIDUNG_SESSION, TKDangNhap);
                    return RedirectToAction("Index", "Home");
                }
                else if (KetQua == 0)
                {
                    ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu!");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản của bạn đã bị khóa!");
                }
            }
            return View("Index");
        }

        public ActionResult DangXuat()
        {
            Session[CommonConstants.NGUOIDUNG_SESSION] = null;
            return RedirectToAction("Index");
        }
    }
}