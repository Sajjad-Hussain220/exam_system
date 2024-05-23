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
    public class tbl_SEMESTER_DETAILSController : Controller
    {
        private db_examsysEntities db = new db_examsysEntities();

        // GET: tbl_SEMESTER_DETAILS
        public ActionResult Index()
        {
            var tbl_SEMESTER_DETAILS = db.tbl_SEMESTER_DETAILS.Include(t => t.tbl_COURSE).Include(t => t.tbl_TEACHER);
            return View(tbl_SEMESTER_DETAILS.ToList());
        }

        // GET: tbl_SEMESTER_DETAILS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_SEMESTER_DETAILS tbl_SEMESTER_DETAILS = db.tbl_SEMESTER_DETAILS.Find(id);
            if (tbl_SEMESTER_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SEMESTER_DETAILS);
        }

        // GET: tbl_SEMESTER_DETAILS/Create
        public ActionResult Create()
        {
            ViewBag.Course_Code = new SelectList(db.tbl_COURSE, "Course_Code", "Course_Name");
            ViewBag.T_ID = new SelectList(db.tbl_TEACHER, "T_ID", "T_Name");
            return View();
        }

        // POST: tbl_SEMESTER_DETAILS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sem_ID,Course_Code,T_ID,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] tbl_SEMESTER_DETAILS tbl_SEMESTER_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.tbl_SEMESTER_DETAILS.Add(tbl_SEMESTER_DETAILS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_Code = new SelectList(db.tbl_COURSE, "Course_Code", "Course_Name", tbl_SEMESTER_DETAILS.Course_Code);
            ViewBag.T_ID = new SelectList(db.tbl_TEACHER, "T_ID", "T_Name", tbl_SEMESTER_DETAILS.T_ID);
            return View(tbl_SEMESTER_DETAILS);
        }

        // GET: tbl_SEMESTER_DETAILS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_SEMESTER_DETAILS tbl_SEMESTER_DETAILS = db.tbl_SEMESTER_DETAILS.Find(id);
            if (tbl_SEMESTER_DETAILS == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_Code = new SelectList(db.tbl_COURSE, "Course_Code", "Course_Name", tbl_SEMESTER_DETAILS.Course_Code);
            ViewBag.T_ID = new SelectList(db.tbl_TEACHER, "T_ID", "T_Name", tbl_SEMESTER_DETAILS.T_ID);
            return View(tbl_SEMESTER_DETAILS);
        }

        // POST: tbl_SEMESTER_DETAILS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sem_ID,Course_Code,T_ID,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] tbl_SEMESTER_DETAILS tbl_SEMESTER_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_SEMESTER_DETAILS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_Code = new SelectList(db.tbl_COURSE, "Course_Code", "Course_Name", tbl_SEMESTER_DETAILS.Course_Code);
            ViewBag.T_ID = new SelectList(db.tbl_TEACHER, "T_ID", "T_Name", tbl_SEMESTER_DETAILS.T_ID);
            return View(tbl_SEMESTER_DETAILS);
        }

        // GET: tbl_SEMESTER_DETAILS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_SEMESTER_DETAILS tbl_SEMESTER_DETAILS = db.tbl_SEMESTER_DETAILS.Find(id);
            if (tbl_SEMESTER_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SEMESTER_DETAILS);
        }

        // POST: tbl_SEMESTER_DETAILS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_SEMESTER_DETAILS tbl_SEMESTER_DETAILS = db.tbl_SEMESTER_DETAILS.Find(id);
            db.tbl_SEMESTER_DETAILS.Remove(tbl_SEMESTER_DETAILS);
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
