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
    public class CourseController : Controller
    {
        private MvcPDbContext db = new MvcPDbContext();

        //
        // GET: /Course/

        public ActionResult Index()
        {
            var coursedbset = db.CourseDbSet.Include(c => c.Department).Include(c => c.Semester);
            return View(coursedbset.ToList());
        }

        //
        // GET: /Course/Details/5

        public ActionResult Details(int id = 0)
        {
            Course course = db.CourseDbSet.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        //
        // GET: /Course/Create

        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.DepartmentdDbSet, "DepartmentId", "DeptCode");
            ViewBag.SemesterId = new SelectList(db.SemesterDbSet, "SemesterId", "SmtName");
            return View();
        }

        //
        // POST: /Course/Create

        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                db.CourseDbSet.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.DepartmentdDbSet, "DepartmentId", "DeptCode", course.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.SemesterDbSet, "SemesterId", "SmtName", course.SemesterId);
            return View(course);
        }

        //
        // GET: /Course/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Course course = db.CourseDbSet.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.DepartmentdDbSet, "DepartmentId", "DeptCode", course.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.SemesterDbSet, "SemesterId", "SmtName", course.SemesterId);
            return View(course);
        }

        //
        // POST: /Course/Edit/5

        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.DepartmentdDbSet, "DepartmentId", "DeptCode", course.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.SemesterDbSet, "SemesterId", "SmtName", course.SemesterId);
            return View(course);
        }

        //
        // GET: /Course/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Course course = db.CourseDbSet.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        //
        // POST: /Course/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.CourseDbSet.Find(id);
            db.CourseDbSet.Remove(course);
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