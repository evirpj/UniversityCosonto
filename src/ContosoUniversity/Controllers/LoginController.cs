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
        // GET: Login 
        // Returns only the view with the form to be filled
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            using(SchoolContext db = new SchoolContext())
            {
                //boolan true or flase
              
                if (db.People.FirstOrDefault(u => u.Login == login && u.Password == password) is Student)
                {
                    Student user = new Student();
                    user.Login = login;
                    user.Password = password;
                    Session["UserName"] = user;

                    return RedirectToAction("Index", "Student");
                }
                else if (db.People.FirstOrDefault(u => u.Login == login && u.Password == password) is Instructor)
                {
                    Instructor user = new Instructor();
                    user.Login = login;
                    user.Password = password;
                    Session["UserName"] = user;
                    return RedirectToAction("Index", "Instructor");
                }
                else
                {
                    TempData["error"] = "Invalid Login or Password";
                }

            }
           

            return RedirectToAction("Login");
        }
    }
}