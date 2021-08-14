using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Nhom8_IMUA.Models;

namespace Nhom8_IMUA.Areas.Admin.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        // GET: Admin/LoaiSanPham
        private Nhom8DB db = new Nhom8DB();
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

            var loaiSanPham = db.LoaiSPs.Select(p => p);

            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                loaiSanPham = loaiSanPham.Where(p => p.TenLoai.Trim().Contains(searchString)); //lọc theo chuỗi tìm kiếm
            }

            switch (sortOrder)
            {
                case "ten_desc":
                    loaiSanPham = loaiSanPham.OrderByDescending(s => s.MaLoai);
                    break;
                default:
                    loaiSanPham = loaiSanPham.OrderBy(s => s.MaLoai);
                    break;
            }
            ViewData["Count"] = loaiSanPham.Count().ToString();
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(loaiSanPham.ToPagedList(pageNumber, pageSize));
        }
    }
}