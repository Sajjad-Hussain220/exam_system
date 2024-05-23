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
    public class tbl_COURSEController : Controller
    {
        private db_examsysEntities db = new db_examsysEntities();

        // GET: tbl_COURSE
        public ActionResult Index()
        {
            return View(db.tbl_COURSE.ToList());
        }

        // GET: tbl_COURSE/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_COURSE tbl_COURSE = db.tbl_COURSE.Find(id);
            if (tbl_COURSE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_COURSE);
        }

        // GET: tbl_COURSE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_COURSE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Course_Code,Course_Name,Course_Type,Credit_Hr,Req_Req,Active,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] tbl_COURSE tbl_COURSE)
        {
            if (ModelState.IsValid)
            {
                db.tbl_COURSE.Add(tbl_COURSE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_COURSE);
        }

        // GET: tbl_COURSE/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_COURSE tbl_COURSE = db.tbl_COURSE.Find(id);
            if (tbl_COURSE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_COURSE);
        }

        // POST: tbl_COURSE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Course_Code,Course_Name,Course_Type,Credit_Hr,Req_Req,Active,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] tbl_COURSE tbl_COURSE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_COURSE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_COURSE);
        }

        // GET: tbl_COURSE/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_COURSE tbl_COURSE = db.tbl_COURSE.Find(id);
            if (tbl_COURSE == null)
            {
                return HttpNotFound();
            }
            return View(tbl_COURSE);
        }

        // POST: tbl_COURSE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_COURSE tbl_COURSE = db.tbl_COURSE.Find(id);
            db.tbl_COURSE.Remove(tbl_COURSE);
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
