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

        // GET
        public ActionResult Create(int? id)
        {
            if (Session["UserName"] is null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Title");
            //StdName is the name of the student who has this ID
            string StdName = db.Students.FirstOrDefault(s => s.ID == id).LastName;
            ViewBag.StudentName = StdName;   
            return View();
        }

        // POST: Create the enrollment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id,[Bind(Include = "EnrollmentID,CourseID")] Enrollment enrollment)
        {
            if (Session["UserName"] is null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                enrollment.StudentID = id;
                if (!db.Enrollments.Where(o => o.StudentID == enrollment.StudentID && o.CourseID == enrollment.CourseID).Any())
                {
                    
                    db.Enrollments.Add(enrollment);
                    db.SaveChanges();
                    //returns to student's details page
                    return RedirectToAction("Details", "Student", new { id });
                }
                else
                {
                    TempData["EnrollError"] = "You already subscribed to this course !";
                }
            } 
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
