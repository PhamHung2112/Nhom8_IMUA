using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nhom8_IMUA.Models;

namespace Nhom8_IMUA.Areas.Admin.Controllers
{
    public class TinTucsController : Controller
    {
        private Nhom8DB db = new Nhom8DB();

        // GET: Admin/TinTucs
        public ActionResult Index()
        {
            return View(db.TinTucs.ToList());
        }

        // GET: Admin/TinTucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTucs.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
        }

        // GET: Admin/TinTucs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TinTucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTinTuc,TieuDe,TomTat,NoiDung,AnhTinTuc")] TinTuc tinTuc)
        {
            if (ModelState.IsValid)
            {
                tinTuc.AnhTinTuc = "";
                var f = Request.Files["AnhTinTuc"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/assets/Images/TinTuc/" + FileName);
                    f.SaveAs(UploadPath);
                    tinTuc.AnhTinTuc = FileName;
                }
                db.TinTucs.Add(tinTuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tinTuc);
        }

        // GET: Admin/TinTucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTucs.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
        }

        // POST: Admin/TinTucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTinTuc,TieuDe,TomTat,NoiDung,AnhTinTuc")] TinTuc tinTuc)
        {

            if (ModelState.IsValid)
            {
                //tinTuc.AnhTinTuc = "";
                //var anh = Request["AnhTT"];
                var f = Request.Files["AnhTinTuc"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/assets/Images/TinTuc/" + FileName);
                    f.SaveAs(UploadPath);
                    tinTuc.AnhTinTuc = FileName;
                }
                db.Entry(tinTuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tinTuc);
        }

        // GET: Admin/TinTucs/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TinTuc tinTuc = db.TinTucs.Find(id);
        //    if (tinTuc == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tinTuc);
        //}

        // POST: Admin/TinTucs/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            TinTuc tinTuc = db.TinTucs.Find(id);
            db.TinTucs.Remove(tinTuc);
            db.SaveChanges();
            return Json(new { ThongBao = "successs" });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
