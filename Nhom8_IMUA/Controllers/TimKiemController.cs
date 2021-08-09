using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Nhom8_IMUA.Models;

namespace Nhom8_IMUA.Controllers
{
    public class TimKiemController : Controller
    {
        private Nhom8DB db = new Nhom8DB();
        // GET: TimKiem
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.SapTheoID = String.IsNullOrEmpty(sortOrder) ? "ten_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var sanphams = db.SanPhams.Select(p => p);

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                sanphams = sanphams.Where(p => p.TenSP.Trim().Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }

            switch (sortOrder)
            {
                case "ten_desc":
                    sanphams = sanphams.OrderByDescending(s => s.MaSP);
                    break;
                default:
                    sanphams = sanphams.OrderBy(s => s.MaSP);
                    break;
            }
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(sanphams.ToPagedList(pageNumber, pageSize));
        }
    }
}