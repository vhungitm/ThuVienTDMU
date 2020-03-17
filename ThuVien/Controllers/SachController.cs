using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models.DAO;
using Models.ViewModel;


namespace ThuVien.Controllers
{
    public class SachController : ApiController
    {
        [HttpGet]
        public IEnumerable<SachViewModel> LayTatCa()
        {
            var dao = new SachDAO();
            return dao.LayTatCa();
        }

        [HttpGet]
        public IEnumerable<SachViewModel> LayTheoLoaiSach(int LoaiSach)
        {
            var dao = new SachDAO();
            return dao.LayTheoLoaiSach(LoaiSach);
        }

        [HttpGet]
        public SachViewModel LayTheoMaSach(long id)
        {
            var dao = new SachDAO();
            return dao.LayTheoMaSach(id);
        }
    }
}