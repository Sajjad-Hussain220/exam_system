using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace examsys.Controllers
{
    public class StudentdetailsController : Controller
    {
        // GET: Studentdetails
        public ActionResult Index()
        {
            return View();
        }

        // GET: Studentdetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Studentdetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Studentdetails/Create
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

        // GET: Studentdetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Studentdetails/Edit/5
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

        // GET: Studentdetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Studentdetails/Delete/5
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
