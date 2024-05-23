using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace examsys.Controllers
{
    public class ExamResultController : Controller
    {
        // GET: ExamResult
        public ActionResult Index()
        {
            return View();
        }

        // GET: ExamResult/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExamResult/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExamResult/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ExamResult/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExamResult/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ExamResult/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExamResult/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
