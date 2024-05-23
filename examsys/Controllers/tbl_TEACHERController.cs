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
    public class tbl_TEACHERController : Controller
    {
        private db_examsysEntities db = new db_examsysEntities();

        // GET: tbl_TEACHER
        public ActionResult Index()
        {
            var tbl_TEACHER = db.tbl_TEACHER.Include(t => t.tbl_DEPARTMENT);
            return View(tbl_TEACHER.ToList());
        }

        // GET: tbl_TEACHER/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TEACHER tbl_TEACHER = db.tbl_TEACHER.Find(id);
            if (tbl_TEACHER == null)
            {
                return HttpNotFound();
            }
            return View(tbl_TEACHER);
        }

        // GET: tbl_TEACHER/Create
        public ActionResult Create()
        {
            ViewBag.D_ID = new SelectList(db.tbl_DEPARTMENT, "D_ID", "D_Name");
            return View();
        }

        // POST: tbl_TEACHER/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "T_ID,T_Name,D_ID,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] tbl_TEACHER tbl_TEACHER)
        {
            if (ModelState.IsValid)
            {
                db.tbl_TEACHER.Add(tbl_TEACHER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.D_ID = new SelectList(db.tbl_DEPARTMENT, "D_ID", "D_Name", tbl_TEACHER.D_ID);
            return View(tbl_TEACHER);
        }

        // GET: tbl_TEACHER/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TEACHER tbl_TEACHER = db.tbl_TEACHER.Find(id);
            if (tbl_TEACHER == null)
            {
                return HttpNotFound();
            }
            ViewBag.D_ID = new SelectList(db.tbl_DEPARTMENT, "D_ID", "D_Name", tbl_TEACHER.D_ID);
            return View(tbl_TEACHER);
        }

        // POST: tbl_TEACHER/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "T_ID,T_Name,D_ID,IsActive,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] tbl_TEACHER tbl_TEACHER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_TEACHER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.D_ID = new SelectList(db.tbl_DEPARTMENT, "D_ID", "D_Name", tbl_TEACHER.D_ID);
            return View(tbl_TEACHER);
        }

        // GET: tbl_TEACHER/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_TEACHER tbl_TEACHER = db.tbl_TEACHER.Find(id);
            if (tbl_TEACHER == null)
            {
                return HttpNotFound();
            }
            return View(tbl_TEACHER);
        }

        // POST: tbl_TEACHER/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_TEACHER tbl_TEACHER = db.tbl_TEACHER.Find(id);
            db.tbl_TEACHER.Remove(tbl_TEACHER);
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
