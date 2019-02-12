using ContosoUniversity.Tests.Tools;
using ContosoUniversity.Controllers;
using ContosoUniversity.DAL;
using ContosoUniversity.Models;
using Moq;
using NUnit.Framework;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System;

namespace ContosoUniversity.Tests.Controllers
{
    class LoginControllerTests : IntegrationTestsBase
    {
        private MockHttpContextWrapper httpContext;
        private LoginController controllerToTest;
        private SchoolContext dbContext;


        [SetUp]
        public void Initialize()
        {
            httpContext = new MockHttpContextWrapper();
            controllerToTest = new LoginController();
            controllerToTest.ControllerContext = new ControllerContext(httpContext.Context.Object, new RouteData(), controllerToTest);
            dbContext = new DAL.SchoolContext(this.ConnectionString);
            controllerToTest.DbContext = dbContext;
        }


        [Test]
        public void LoginSuccessStudent()
        {
            string testLastName = "Hounnou";
            string testFirstName = "Koffi";
            string testLogin = "hounnouko";
            string testPwd = "ffiko";
            string testMailAdresse = "koff@houn.com";
            DateTime testEnrollmentDate = DateTime.Now;

            EntityGenerator generator = new EntityGenerator(dbContext);
            Student student = generator.CreateStudentForLogin(testLastName, testFirstName, testLogin, testPwd, testMailAdresse, testEnrollmentDate);

            var result = controllerToTest.Login(testLogin, testPwd) as RedirectToRouteResult;

            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.RouteValues["action"], Is.EqualTo("Details"));

            //Assert.That(controllerToTest.Session["UserName"], Is.Not.Null);
           

        }

        [Test]
        public void LoginSuccessInstructor()
        {
            string testLastName = "Hounnou";
            string testFirstName = "Koffi";
            string testLogin = "hounnouko";
            string testPwd = "ffiko";
            string testMailAdresse = "koff@houn.com";
            DateTime testHireDate = DateTime.Now;

            EntityGenerator generator = new EntityGenerator(dbContext);
            Instructor instructor = generator.CreateInstructorForLogin(testLastName, testFirstName, testLogin, testPwd, testMailAdresse, testHireDate);

            var result = controllerToTest.Login(testLogin, testPwd) as RedirectToRouteResult;


            Assert.That(result, Is.Not.Null);
            Assert.That(result.RouteValues["action"], Is.EqualTo("Details"));

            //Assert.That(controllerToTest.Session["UserName"], Is.Not.Null);


        }


        [Test]
        public void LoginFail_Student_WrongPwd()
        {
            string testLastName = "Hounnou";
            string testFirstName = "Koffi";
            string testLogin = "hounnouko";
            string testRightPwd = "ffiko";
            string testWrongPwd = "koffi";
            string testMailAdresse = "koff@houn.com";
            DateTime testEnrollmentDate = DateTime.Now;

            EntityGenerator generator = new EntityGenerator(dbContext);
            Student student = generator.CreateStudentForLogin(testLastName, testFirstName, testLogin, testRightPwd, testMailAdresse, testEnrollmentDate);

            var result = controllerToTest.Login(testLogin, testWrongPwd) as RedirectToRouteResult;


            Assert.That(result, Is.Not.Null);
            Assert.That(result.RouteValues["action"], Is.EqualTo("Login"));

        }


        [Test]
        public void LoginFail_Student_WrongLogin()
        {
            string testLastName = "Hounnou";
            string testFirstName = "Koffi";
            string testRightLogin = "hounnouko";
            string testWrongLogin = "hounnou";
            string testPwd = "ffiko";
            string testMailAdresse = "koff@houn.com";
            DateTime testEnrollmentDate = DateTime.Now;

            EntityGenerator generator = new EntityGenerator(dbContext);
            Student student = generator.CreateStudentForLogin(testLastName, testFirstName, testRightLogin, testPwd, testMailAdresse, testEnrollmentDate);

            var result = controllerToTest.Login(testWrongLogin, testPwd) as RedirectToRouteResult;


            Assert.That(result, Is.Not.Null);
            Assert.That(result.RouteValues["action"], Is.EqualTo("Login"));

        }

        [Test]
        public void Logout_Student()
        {

        }

        [Test]
        public void Logout_Instructor()
        {

        }


    }
}
