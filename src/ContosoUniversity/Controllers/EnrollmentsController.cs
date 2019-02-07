using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.DAL;
using ContosoUniversity.Models;

namespace ContosoUniversity.Controllers
{
    public class EnrollmentsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        
        public ActionResult Create()
        {
            if (Session["UserName"] is null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title");
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName");
            
            return View();
        }

        // POST: Create the enrollment
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(int id,[Bind(Include = "EnrollmentID,CourseID,Grade")] Enrollment enrollment)
        public ActionResult Create([Bind(Include = "EnrollmentID,StudentID,CourseID")] Enrollment enrollment)
        {
            if (Session["UserName"] is null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                if (!db.Enrollments.Where(o => o.StudentID == enrollment.StudentID && o.CourseID == enrollment.CourseID).Any())
                {
                    //enrollment.StudentID = id;
                    db.Enrollments.Add(enrollment);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Student");
                }
                else
                {
                    TempData["EnrollError"] = "You already subscribed to this course !";
                }
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title", enrollment.CourseID);
            ViewBag.StudentID = new SelectList(db.People, "ID", "LastName", enrollment.StudentID);
            return RedirectToAction("Create");
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
