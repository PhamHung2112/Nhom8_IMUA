﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nhom8_IMUA.Common;
using Nhom8_IMUA.Models;

namespace Nhom8_IMUA.Areas.Admin.Controllers
{
    public class UyQuyensController : Controller
    {
        private Nhom8DB db = new Nhom8DB();

        // GET: Admin/UyQuyens
        [HasCredential(RoleID = "VIEW_CREDENTIAL")]
        public ActionResult Index()
        {
            var credentials = db.Credentials.Include(c => c.Role).Include(c => c.UserGroup);
            return View(credentials.ToList());
        }

        // GET: Admin/UyQuyens/Details/5
        [HasCredential(RoleID = "VIEW_CREDENTIAL")]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Credential credential = db.Credentials.Find(id);
            if (credential == null)
            {
                return HttpNotFound();
            }
            return View(credential);
        }

        // GET: Admin/UyQuyens/Create
        [HasCredential(RoleID = "ADD_CREDENTIAL")]
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "Name");
            ViewBag.GroupID = new SelectList(db.UserGroups, "GroupID", "Name");
            return View();
        }

        // POST: Admin/UyQuyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CredentialID,GroupID,RoleID")] Credential credential)
        {
            if (ModelState.IsValid)
            {
                db.Credentials.Add(credential);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "Name", credential.RoleID);
            ViewBag.GroupID = new SelectList(db.UserGroups, "GroupID", "Name", credential.GroupID);
            return View(credential);
        }

        // GET: Admin/UyQuyens/Edit/5
        [HasCredential(RoleID = "EDIT_CREDENTIAL")]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Credential credential = db.Credentials.Find(id);
            if (credential == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "Name", credential.RoleID);
            ViewBag.GroupID = new SelectList(db.UserGroups, "GroupID", "Name", credential.GroupID);
            return View(credential);
        }

        // POST: Admin/UyQuyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CredentialID,GroupID,RoleID")] Credential credential)
        {
            if (ModelState.IsValid)
            {
                db.Entry(credential).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "Name", credential.RoleID);
            ViewBag.GroupID = new SelectList(db.UserGroups, "GroupID", "Name", credential.GroupID);
            return View(credential);
        }

        // GET: Admin/UyQuyens/Delete/5
        [HasCredential(RoleID = "DELETE_CREDENTIAL")]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Credential credential = db.Credentials.Find(id);
            if (credential == null)
            {
                return HttpNotFound();
            }
            return View(credential);
        }

        // POST: Admin/UyQuyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Credential credential = db.Credentials.Find(id);
            db.Credentials.Remove(credential);
            db.SaveChanges();
            return RedirectToAction("Index");
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
