using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplicationProjectApp.Models;

namespace MvcApplicationProjectApp.Controllers
{
    public class SemesterController : Controller
    {
        private MvcPDbContext db = new MvcPDbContext();

        //
        // GET: /Semester/

        public ActionResult Index()
        {
            return View(db.SemesterDbSet.ToList());
        }

        //
        // GET: /Semester/Details/5

        public ActionResult Details(int id = 0)
        {
            Semester semester = db.SemesterDbSet.Find(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            return View(semester);
        }

        //
        // GET: /Semester/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Semester/Create

        [HttpPost]
        public ActionResult Create(Semester semester)
        {
            if (ModelState.IsValid)
            {
                db.SemesterDbSet.Add(semester);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(semester);
        }

        //
        // GET: /Semester/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Semester semester = db.SemesterDbSet.Find(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            return View(semester);
        }

        //
        // POST: /Semester/Edit/5

        [HttpPost]
        public ActionResult Edit(Semester semester)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semester).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(semester);
        }

        //
        // GET: /Semester/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Semester semester = db.SemesterDbSet.Find(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            return View(semester);
        }

        //
        // POST: /Semester/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Semester semester = db.SemesterDbSet.Find(id);
            db.SemesterDbSet.Remove(semester);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}