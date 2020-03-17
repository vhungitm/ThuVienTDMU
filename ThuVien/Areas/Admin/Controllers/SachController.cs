using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EF;
using Models.DAO;

namespace ThuVien.Areas.Admin.Controllers
{
    public class SachController : BaseController
    {
        // GET: Admin/Sach
        public ActionResult Index(string TimKiem, int Trang = 1, int KTTrang = 10)
        {
            var dao = new SachDAO();
            var DSSach = dao.LayDSTheoTrang(TimKiem, Trang, KTTrang);
            ViewBag.TimKiem = TimKiem;
            return View(DSSach);
        }

        public ActionResult ThemMoi()
        {
            DatViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(Sach sach)
        {
            DatViewBag();
            if (ModelState.IsValid)
            {
                var dao = new SachDAO();
                var KetQua = dao.ThemMoi(sach);

                if (KetQua > 0)
                {
                    DatThongBao("Thêm mới sách thành công!", LoaiThongBao.ThanhCong);
                    return RedirectToAction("Index", "Sach");
                }
                else
                {
                    DatThongBao("Thêm mới sách không thành công!", LoaiThongBao.Loi);
                }
            }
            return View();
        }

        public ActionResult CapNhat(long id)
        {
            var dao = new SachDAO();
            var KetQua = dao.TimTheoMaSach(id);

            DatViewBag(KetQua.MaLoai, KetQua.MaNXB);
            if (KetQua != null)
            {
                return View(KetQua);
            }
            return Redirect("/404");
        }

        [HttpPost]
        public ActionResult CapNhat(Sach sach)
        {
            DatViewBag(sach.MaLoai, sach.MaNXB);
            if (ModelState.IsValid)
            {
                var dao = new SachDAO();
                var KetQua = dao.CapNhat(sach);

                if(KetQua > 0)
                {
                    DatThongBao("Cập nhật thông tin sách thành công!", LoaiThongBao.ThanhCong);
                    return RedirectToAction("Index", "Sach");
                }
                else
                {
                    DatThongBao("Cập nhật thông tin sách không thành công!", LoaiThongBao.Loi);
                }
            }
            return View();
        }

        public ActionResult Xoa(long id)
        {
            var dao = new SachDAO();
            var ThongTin = dao.TimTheoMaSach(id);

            if (ThongTin != null)
            {
                var KetQua = dao.Xoa(id);

                if (KetQua > 0)
                {
                    DatThongBao("Xóa sách thành công!", LoaiThongBao.ThanhCong);
                }
                else
                {
                    DatThongBao("Xóa sách không thành công!", LoaiThongBao.Loi);
                }
                return RedirectToAction("Index");
            }
            return Redirect("/404");
        }

        public void DatViewBag(int? MaLoai = null, int? MaNXB = null)
        {
            var DSLoaiSach = new LoaiSachDAO().LayTatCa();
            var DSNhaXuatBan = new NhaXuatBanDAO().LayTatCa();

            ViewBag.MaLoai = new SelectList(DSLoaiSach, "MaLoai", "TenLoai", MaLoai);
            ViewBag.MaNXB = new SelectList(DSNhaXuatBan, "MaNXB", "TenNXB", MaNXB);
        }
    }
}