using ContosoUniversity.DAL;
using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversity.Controllers
{
    public class LoginController : Controller
    {
        private SchoolContext db = new SchoolContext();
        public SchoolContext DbContext
        {
            get { return db; }
            set { db = value; }
        }
        // GET: Login 
        // Returns only the view with the form to be filled to login
        public ActionResult Login()
        {

            return View();
        }

        // POST: Takes the login and password we entered in GET and allows the user to login
        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            //using(SchoolContext db = new SchoolContext())
            {
                //FirstOrDefault returns a person, check if it is a student or instructor
              
                if (db.People.FirstOrDefault(u => u.Login == login && u.Password == password) is Student)
                {   
                    Person user = db.People.FirstOrDefault(u => u.Login == login && u.Password == password);
                    
                    //Session is not empty, it means you are connected
                    Session["UserName"] = user;
                    // Redirects you to your HomePage
                    return RedirectToAction("Index", "Student");
                }
                else if (db.People.FirstOrDefault(u => u.Login == login && u.Password == password) is Instructor)
                {
                    
                    Person user = db.People.FirstOrDefault(u => u.Login == login && u.Password == password);
                    
                    //Session is not empty, it means you are connected
                    Session["UserName"] = user;
                    // Redirects you to your HomePage
                    return RedirectToAction("Index", "Instructor");
                }
                else
                {   // Prints error message
                    TempData["error"] = "Invalid Login or Password";
                }

            }
           

            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        { 

            Session["UserName"] = null;

            return RedirectToAction("Index", "Home"); 
        }
    }
}