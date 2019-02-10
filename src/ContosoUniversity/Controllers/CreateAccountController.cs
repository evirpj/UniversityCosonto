using ContosoUniversity.DAL;
using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ContosoUniversity.Controllers
{
    public class CreateAccountController : Controller
    {
        SchoolContext db = new SchoolContext();

        // GET: CreateAccount
        [HttpGet]
        public ActionResult CreateAccount()
        {
            // Create a list of the two possible types, instructor and student
            List<string> accountTypes = new List<string>();
            accountTypes.Add("Student");
            accountTypes.Add("Instructor");
            ViewBag.Message = accountTypes;
            return View();
        }

        [HttpPost]
        public ActionResult CreateAccount(string accountType, string LastName, string FirstMidName, string MailAdresse, string Login, string Password)
        { 
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (ModelState.IsValid)
            {
                if (accountType == "Instructor" && !db.People.Any(u => u.Login == Login))
                {

                    Instructor instructor = new Instructor();
                    instructor.LastName = LastName;
                    instructor.FirstMidName = FirstMidName;
                    instructor.MailAdresse = LastName;
                    instructor.Login = Login;
                    instructor.Password = Password;
                    instructor.HireDate = DateTime.Parse(DateTime.Now.ToString());
                    db.Instructors.Add(instructor);
                    db.SaveChanges();
                    //instructor.ID 
                    Session["UserName"] = instructor;
                    return RedirectToAction("Index", "Instructor");

                   
                }

                else if (accountType == "Student" && !db.People.Any(u => u.Login == Login))
                {


                    Student student = new Student();
                    student.LastName = LastName;
                    student.FirstMidName = FirstMidName;
                    student.MailAdresse = LastName;
                    student.Login = Login;
                    student.Password = Password;
                    student.EnrollmentDate = DateTime.Parse(DateTime.Now.ToString());
                    db.Students.Add(student);
                    db.SaveChanges();
                    Session["UserName"] = student;
                    return RedirectToAction("Index", "Student");
                }
               
                 TempData["error"]= "This login already exists";
                    
                
                List<string> accountTypes = new List<string>();
                accountTypes.Add("Student");
                accountTypes.Add("Instructor");
                ViewBag.Message = accountTypes;
                return View();
                
                
                
            }  
        

        return View(); 
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