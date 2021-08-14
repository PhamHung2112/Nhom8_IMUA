using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nhom8_IMUA.Models;
using PagedList;

namespace Nhom8_IMUA.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        private Nhom8DB db = new Nhom8DB();

        // GET: Admin/Customer
        public ActionResult Index(int? page)
        {
            var custom = db.NguoiDungs.Select(x=>x);
            custom = custom.OrderBy(c => c.MaND);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(custom.ToPagedList(pageNumber, pageSize));
        }
        
        // GET: Admin/Customer/Edit/5
        public ActionResult ChangeStatus(int? id)
        {
            Response.Write("<script>alert(" + id + ");</script>");
            if (id==null)
            {
                return RedirectToAction("Index");
            }
            NguoiDung custom = db.NguoiDungs.Find(id);
            if (custom.TrangThai.Equals(false))
            {
                custom.TrangThai = true;
            }
            else
            {
                custom.TrangThai = false;
            }
            db.Entry(custom).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
