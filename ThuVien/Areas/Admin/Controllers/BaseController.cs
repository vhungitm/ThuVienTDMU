using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ThuVien.Common;
namespace ThuVien.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (TaiKhoanDangNhap)Session[CommonConstants.NGUOIDUNG_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "DangNhap", action = "Index", Area = "Admin" }));
            }
            base.OnActionExecuting(filterContext);
        }
        protected void DatThongBao(string ThongBao, LoaiThongBao Loai)
        {
            TempData["ThongBao"] = ThongBao;
            if (Loai == LoaiThongBao.ThanhCong)
            {
                TempData["LoaiThongBao"] = "alert-success";
            }
            else if (Loai == LoaiThongBao.CanhBao)
            {
                TempData["LoaiThongBao"] = "alert-warrning";
            }
            else if (Loai == LoaiThongBao.Loi)
            {
                TempData["LoaiThongBao"] = "alert-danger";
            }
        }
        protected enum LoaiThongBao
        {
            ThanhCong,
            Loi,
            CanhBao,
        }
	}
}