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
    public class tbl_DEPARTMENTController : Controller
    {
        private db_examsysEntities db = new db_examsysEntities();

        // GET: tbl_DEPARTMENT
        public ActionResult Index()
        {
            return View(db.tbl_DEPARTMENT.ToList());
        }

        // GET: tbl_DEPARTMENT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DEPARTMENT tbl_DEPARTMENT = db.tbl_DEPARTMENT.Find(id);
            if (tbl_DEPARTMENT == null)
            {
                return HttpNotFound();
            }
            return View(tbl_DEPARTMENT);
        }

        // GET: tbl_DEPARTMENT/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_DEPARTMENT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "D_ID,D_Name,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] tbl_DEPARTMENT tbl_DEPARTMENT)
        {
            if (ModelState.IsValid)
            {
                db.tbl_DEPARTMENT.Add(tbl_DEPARTMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_DEPARTMENT);
        }

        // GET: tbl_DEPARTMENT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DEPARTMENT tbl_DEPARTMENT = db.tbl_DEPARTMENT.Find(id);
            if (tbl_DEPARTMENT == null)
            {
                return HttpNotFound();
            }
            return View(tbl_DEPARTMENT);
        }

        // POST: tbl_DEPARTMENT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "D_ID,D_Name,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] tbl_DEPARTMENT tbl_DEPARTMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_DEPARTMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_DEPARTMENT);
        }

        // GET: tbl_DEPARTMENT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DEPARTMENT tbl_DEPARTMENT = db.tbl_DEPARTMENT.Find(id);
            if (tbl_DEPARTMENT == null)
            {
                return HttpNotFound();
            }
            return View(tbl_DEPARTMENT);
        }

        // POST: tbl_DEPARTMENT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_DEPARTMENT tbl_DEPARTMENT = db.tbl_DEPARTMENT.Find(id);
            db.tbl_DEPARTMENT.Remove(tbl_DEPARTMENT);
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
