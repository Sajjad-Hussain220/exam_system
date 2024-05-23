using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using examsys.Models;

namespace examsys.Controllers
{
    public class tbl_STUDENT_AUDITController : Controller
    {
        private db_examsysEntities db = new db_examsysEntities();

        // GET: tbl_STUDENT_AUDIT
        public ActionResult Index()
        {
            return View(db.tbl_STUDENT_AUDIT.ToList());
        }

        // GET: tbl_STUDENT_AUDIT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_STUDENT_AUDIT tbl_STUDENT_AUDIT = db.tbl_STUDENT_AUDIT.Find(id);
            if (tbl_STUDENT_AUDIT == null)
            {
                return HttpNotFound();
            }
            return View(tbl_STUDENT_AUDIT);
        }

        // GET: tbl_STUDENT_AUDIT/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_STUDENT_AUDIT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Audit_ID,St_ID,ChangeType,ChangeDate")] tbl_STUDENT_AUDIT tbl_STUDENT_AUDIT)
        {
            if (ModelState.IsValid)
            {
                db.tbl_STUDENT_AUDIT.Add(tbl_STUDENT_AUDIT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_STUDENT_AUDIT);
        }

        // GET: tbl_STUDENT_AUDIT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_STUDENT_AUDIT tbl_STUDENT_AUDIT = db.tbl_STUDENT_AUDIT.Find(id);
            if (tbl_STUDENT_AUDIT == null)
            {
                return HttpNotFound();
            }
            return View(tbl_STUDENT_AUDIT);
        }

        // POST: tbl_STUDENT_AUDIT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Audit_ID,St_ID,ChangeType,ChangeDate")] tbl_STUDENT_AUDIT tbl_STUDENT_AUDIT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_STUDENT_AUDIT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_STUDENT_AUDIT);
        }

        // GET: tbl_STUDENT_AUDIT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_STUDENT_AUDIT tbl_STUDENT_AUDIT = db.tbl_STUDENT_AUDIT.Find(id);
            if (tbl_STUDENT_AUDIT == null)
            {
                return HttpNotFound();
            }
            return View(tbl_STUDENT_AUDIT);
        }

        // POST: tbl_STUDENT_AUDIT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_STUDENT_AUDIT tbl_STUDENT_AUDIT = db.tbl_STUDENT_AUDIT.Find(id);
            db.tbl_STUDENT_AUDIT.Remove(tbl_STUDENT_AUDIT);
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
