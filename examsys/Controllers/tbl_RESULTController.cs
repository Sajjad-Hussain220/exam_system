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
    public class tbl_RESULTController : Controller
    {
        private db_examsysEntities db = new db_examsysEntities();

        // GET: tbl_RESULT
        public ActionResult Index()
        {
            var tbl_RESULT = db.tbl_RESULT.Include(t => t.tbl_COURSE).Include(t => t.tbl_EXAM).Include(t => t.tbl_SEMESTER_DETAILS).Include(t => t.tbl_STUDENT);
            return View(tbl_RESULT.ToList());
        }

        // GET: tbl_RESULT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_RESULT tbl_RESULT = db.tbl_RESULT.Find(id);
            if (tbl_RESULT == null)
            {
                return HttpNotFound();
            }
            return View(tbl_RESULT);
        }

        // GET: tbl_RESULT/Create
        public ActionResult Create()
        {
            ViewBag.Course_Code = new SelectList(db.tbl_COURSE, "Course_Code", "Course_Name");
            ViewBag.Exam_ID = new SelectList(db.tbl_EXAM, "Room_no", "Exam_Type");
            ViewBag.Sem_ID = new SelectList(db.tbl_SEMESTER_DETAILS, "Sem_ID", "Course_Code");
            ViewBag.St_ID = new SelectList(db.tbl_STUDENT, "St_ID", "St_Name");
            return View();
        }

        // POST: tbl_RESULT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sem_ID,Course_Code,St_ID,Exam_ID,Marks,Grade,Result_Date,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] tbl_RESULT tbl_RESULT)
        {
            if (ModelState.IsValid)
            {
                db.tbl_RESULT.Add(tbl_RESULT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_Code = new SelectList(db.tbl_COURSE, "Course_Code", "Course_Name", tbl_RESULT.Course_Code);
            ViewBag.Exam_ID = new SelectList(db.tbl_EXAM, "Room_no", "Exam_Type", tbl_RESULT.Exam_ID);
            ViewBag.Sem_ID = new SelectList(db.tbl_SEMESTER_DETAILS, "Sem_ID", "Course_Code", tbl_RESULT.Sem_ID);
            ViewBag.St_ID = new SelectList(db.tbl_STUDENT, "St_ID", "St_Name", tbl_RESULT.St_ID);
            return View(tbl_RESULT);
        }

        // GET: tbl_RESULT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_RESULT tbl_RESULT = db.tbl_RESULT.Find(id);
            if (tbl_RESULT == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_Code = new SelectList(db.tbl_COURSE, "Course_Code", "Course_Name", tbl_RESULT.Course_Code);
            ViewBag.Exam_ID = new SelectList(db.tbl_EXAM, "Room_no", "Exam_Type", tbl_RESULT.Exam_ID);
            ViewBag.Sem_ID = new SelectList(db.tbl_SEMESTER_DETAILS, "Sem_ID", "Course_Code", tbl_RESULT.Sem_ID);
            ViewBag.St_ID = new SelectList(db.tbl_STUDENT, "St_ID", "St_Name", tbl_RESULT.St_ID);
            return View(tbl_RESULT);
        }

        // POST: tbl_RESULT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sem_ID,Course_Code,St_ID,Exam_ID,Marks,Grade,Result_Date,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] tbl_RESULT tbl_RESULT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_RESULT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_Code = new SelectList(db.tbl_COURSE, "Course_Code", "Course_Name", tbl_RESULT.Course_Code);
            ViewBag.Exam_ID = new SelectList(db.tbl_EXAM, "Room_no", "Exam_Type", tbl_RESULT.Exam_ID);
            ViewBag.Sem_ID = new SelectList(db.tbl_SEMESTER_DETAILS, "Sem_ID", "Course_Code", tbl_RESULT.Sem_ID);
            ViewBag.St_ID = new SelectList(db.tbl_STUDENT, "St_ID", "St_Name", tbl_RESULT.St_ID);
            return View(tbl_RESULT);
        }

        // GET: tbl_RESULT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_RESULT tbl_RESULT = db.tbl_RESULT.Find(id);
            if (tbl_RESULT == null)
            {
                return HttpNotFound();
            }
            return View(tbl_RESULT);
        }

        // POST: tbl_RESULT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_RESULT tbl_RESULT = db.tbl_RESULT.Find(id);
            db.tbl_RESULT.Remove(tbl_RESULT);
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
