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
    public class tbl_STUDENTController : Controller
    {
        private db_examsysEntities db = new db_examsysEntities();

        // GET: tbl_STUDENT
        public ActionResult Index()
        {
            return View(db.tbl_STUDENT.ToList());
        }

        // GET: tbl_STUDENT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_STUDENT tbl_STUDENT = db.tbl_STUDENT.Find(id);
            if (tbl_STUDENT == null)
            {
                return HttpNotFound();
            }
            return View(tbl_STUDENT);
        }

        // GET: tbl_STUDENT/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_STUDENT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "St_ID,St_Name,Contact,Fee_Payment,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] tbl_STUDENT tbl_STUDENT)
        {
            if (ModelState.IsValid)
            {
                db.tbl_STUDENT.Add(tbl_STUDENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_STUDENT);
        }

        // GET: tbl_STUDENT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_STUDENT tbl_STUDENT = db.tbl_STUDENT.Find(id);
            if (tbl_STUDENT == null)
            {
                return HttpNotFound();
            }
            return View(tbl_STUDENT);
        }

        // POST: tbl_STUDENT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "St_ID,St_Name,Contact,Fee_Payment,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] tbl_STUDENT tbl_STUDENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_STUDENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_STUDENT);
        }

        // GET: tbl_STUDENT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_STUDENT tbl_STUDENT = db.tbl_STUDENT.Find(id);
            if (tbl_STUDENT == null)
            {
                return HttpNotFound();
            }
            return View(tbl_STUDENT);
        }

        // POST: tbl_STUDENT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_STUDENT tbl_STUDENT = db.tbl_STUDENT.Find(id);
            db.tbl_STUDENT.Remove(tbl_STUDENT);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetResult(int id)
        {
            var studentResult = db.tbl_RESULT
                .Where(r => r.St_ID == id)
                .ToList();

            if (studentResult == null || !studentResult.Any())
            {
                return HttpNotFound();
            }

            var report = new Report1(); 
            report.DataSource = studentResult; 

            return View(report);
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
