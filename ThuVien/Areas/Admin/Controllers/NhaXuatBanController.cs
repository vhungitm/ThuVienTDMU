using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using Models.EF;

namespace ThuVien.Areas.Admin.Controllers
{
    public class NhaXuatBanController : BaseController
    {
        // GET: Admin/NhaXuatBan
        public ActionResult Index(string TimKiem, int Trang = 1, int KTTrang = 10)
        {
            var dao = new NhaXuatBanDAO();
            var DSNhaXuatBan = dao.LayDSTheoTrang(TimKiem, Trang, KTTrang);
            ViewBag.TimKiem = TimKiem;
            return View(DSNhaXuatBan);
        }

        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(NhaXuatBan nhaxuatban)
        {
            if (ModelState.IsValid)
            {
                var dao = new NhaXuatBanDAO();
                var KetQua = dao.ThemMoi(nhaxuatban);

                if(KetQua > 0)
                {
                    DatThongBao("Thêm mới nhà xuất bản thành công!", LoaiThongBao.ThanhCong);
                    return RedirectToAction("Index", "NhaXuatBan");
                }
                else
                {
                    DatThongBao("Thêm mới nhà xuất bản không thành công!", LoaiThongBao.Loi);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult CapNhat(int id)
        {
            var dao = new NhaXuatBanDAO();
            var ThongTin = dao.TimTheoMaNXB(id);

            if(ThongTin != null){
                return View(ThongTin);
            }
            return Redirect("/404");
        }

        [HttpPost]
        public ActionResult CapNhat(NhaXuatBan nhaxuatban)
        {
            if (ModelState.IsValid)
            {
                var dao = new NhaXuatBanDAO();
                var KetQua = dao.CapNhat(nhaxuatban);

                if(KetQua > 0)
                {
                    DatThongBao("Cập nhật thông tin nhà xuất bản thành công!", LoaiThongBao.ThanhCong);
                    return RedirectToAction("Index", "NhaXuatBan");
                }
                else
                {
                    DatThongBao("Cập nhật thông tin nhà xuất bản không thành công!", LoaiThongBao.Loi);
                }
            }
            return View();
        }

        public ActionResult Xoa(int id)
        {
            var dao = new NhaXuatBanDAO();
            var ThongTin = dao.TimTheoMaNXB(id);

            if (ThongTin != null)
            {
                var KetQua = dao.Xoa(id);

                if (KetQua > 0)
                {
                    DatThongBao("Xóa nhà xuất bản thành công!", LoaiThongBao.ThanhCong);
                }
                else
                {
                    DatThongBao("Xóa nhà xuất bản không thành công!", LoaiThongBao.Loi);
                }
                return RedirectToAction("Index");
            }
            return Redirect("/404");
        }
    }
}