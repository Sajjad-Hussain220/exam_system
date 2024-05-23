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
    public class tbl_STUDENT_SEMESTERController : Controller
    {
        private db_examsysEntities db = new db_examsysEntities();

        // GET: tbl_STUDENT_SEMESTER
        public ActionResult Index()
        {
            var tbl_STUDENT_SEMESTER = db.tbl_STUDENT_SEMESTER.Include(t => t.tbl_SEMESTER_DETAILS).Include(t => t.tbl_STUDENT);
            return View(tbl_STUDENT_SEMESTER.ToList());
        }

        // GET: tbl_STUDENT_SEMESTER/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_STUDENT_SEMESTER tbl_STUDENT_SEMESTER = db.tbl_STUDENT_SEMESTER.Find(id);
            if (tbl_STUDENT_SEMESTER == null)
            {
                return HttpNotFound();
            }
            return View(tbl_STUDENT_SEMESTER);
        }

        // GET: tbl_STUDENT_SEMESTER/Create
        public ActionResult Create()
        {
            ViewBag.Sem_ID = new SelectList(db.tbl_SEMESTER_DETAILS, "Sem_ID", "Course_Code");
            ViewBag.St_ID = new SelectList(db.tbl_STUDENT, "St_ID", "St_Name");
            return View();
        }

        // POST: tbl_STUDENT_SEMESTER/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "St_ID,Sem_ID,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] tbl_STUDENT_SEMESTER tbl_STUDENT_SEMESTER)
        {
            if (ModelState.IsValid)
            {
                db.tbl_STUDENT_SEMESTER.Add(tbl_STUDENT_SEMESTER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sem_ID = new SelectList(db.tbl_SEMESTER_DETAILS, "Sem_ID", "Course_Code", tbl_STUDENT_SEMESTER.Sem_ID);
            ViewBag.St_ID = new SelectList(db.tbl_STUDENT, "St_ID", "St_Name", tbl_STUDENT_SEMESTER.St_ID);
            return View(tbl_STUDENT_SEMESTER);
        }

        // GET: tbl_STUDENT_SEMESTER/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_STUDENT_SEMESTER tbl_STUDENT_SEMESTER = db.tbl_STUDENT_SEMESTER.Find(id);
            if (tbl_STUDENT_SEMESTER == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sem_ID = new SelectList(db.tbl_SEMESTER_DETAILS, "Sem_ID", "Course_Code", tbl_STUDENT_SEMESTER.Sem_ID);
            ViewBag.St_ID = new SelectList(db.tbl_STUDENT, "St_ID", "St_Name", tbl_STUDENT_SEMESTER.St_ID);
            return View(tbl_STUDENT_SEMESTER);
        }

        // POST: tbl_STUDENT_SEMESTER/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "St_ID,Sem_ID,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] tbl_STUDENT_SEMESTER tbl_STUDENT_SEMESTER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_STUDENT_SEMESTER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sem_ID = new SelectList(db.tbl_SEMESTER_DETAILS, "Sem_ID", "Course_Code", tbl_STUDENT_SEMESTER.Sem_ID);
            ViewBag.St_ID = new SelectList(db.tbl_STUDENT, "St_ID", "St_Name", tbl_STUDENT_SEMESTER.St_ID);
            return View(tbl_STUDENT_SEMESTER);
        }

        // GET: tbl_STUDENT_SEMESTER/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_STUDENT_SEMESTER tbl_STUDENT_SEMESTER = db.tbl_STUDENT_SEMESTER.Find(id);
            if (tbl_STUDENT_SEMESTER == null)
            {
                return HttpNotFound();
            }
            return View(tbl_STUDENT_SEMESTER);
        }

        // POST: tbl_STUDENT_SEMESTER/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_STUDENT_SEMESTER tbl_STUDENT_SEMESTER = db.tbl_STUDENT_SEMESTER.Find(id);
            db.tbl_STUDENT_SEMESTER.Remove(tbl_STUDENT_SEMESTER);
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
