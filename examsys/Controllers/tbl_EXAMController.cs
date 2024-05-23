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
    public class tbl_EXAMController : Controller
    {
        private db_examsysEntities db = new db_examsysEntities();

        // GET: tbl_EXAM
        public ActionResult Index()
        {
            return View(db.tbl_EXAM.ToList());
        }

        // GET: tbl_EXAM/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_EXAM tbl_EXAM = db.tbl_EXAM.Find(id);
            if (tbl_EXAM == null)
            {
                return HttpNotFound();
            }
            return View(tbl_EXAM);
        }

        // GET: tbl_EXAM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_EXAM/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Room_no,Exam_Type,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] tbl_EXAM tbl_EXAM)
        {
            if (ModelState.IsValid)
            {
                db.tbl_EXAM.Add(tbl_EXAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_EXAM);
        }

        // GET: tbl_EXAM/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_EXAM tbl_EXAM = db.tbl_EXAM.Find(id);
            if (tbl_EXAM == null)
            {
                return HttpNotFound();
            }
            return View(tbl_EXAM);
        }

        // POST: tbl_EXAM/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Room_no,Exam_Type,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] tbl_EXAM tbl_EXAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_EXAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_EXAM);
        }

        // GET: tbl_EXAM/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_EXAM tbl_EXAM = db.tbl_EXAM.Find(id);
            if (tbl_EXAM == null)
            {
                return HttpNotFound();
            }
            return View(tbl_EXAM);
        }

        // POST: tbl_EXAM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_EXAM tbl_EXAM = db.tbl_EXAM.Find(id);
            db.tbl_EXAM.Remove(tbl_EXAM);
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
