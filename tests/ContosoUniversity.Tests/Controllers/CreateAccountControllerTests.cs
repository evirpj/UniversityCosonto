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
    class CreateAccountControllerTests : IntegrationTestsBase
    {
        private MockHttpContextWrapper httpContext;
        private CreateAccountController controllerToTest;
        private SchoolContext dbContext;


        [SetUp]
        public void Initialize()
        {
            httpContext = new MockHttpContextWrapper();
            controllerToTest = new CreateAccountController();
            controllerToTest.ControllerContext = new ControllerContext(httpContext.Context.Object, new RouteData(), controllerToTest);
            dbContext = new DAL.SchoolContext(this.ConnectionString);
            controllerToTest.DbContext = dbContext;
        }


        [Test]
        public void CreationSuccesfulStudent()
        {
            string testAccountType = "Student";
            string testLastName = "Hounnou";
            string testFirstName = "Koffi";
            string testLogin = "hounnouko";
            string testPwd = "ffiko";
            string testMailAdresse = "koff@houn.com";
            DateTime testEnrollmentDate = DateTime.Now;

            EntityGenerator generator = new EntityGenerator(dbContext);
            Student student = generator.CreateStudentForLogin(testLastName, testFirstName, testLogin, testPwd, testMailAdresse, testEnrollmentDate);

            var result = controllerToTest.CreateAccount(testAccountType, testLastName, testFirstName, testMailAdresse, testLogin, testPwd) as ViewResult;
            var resultStudent = controllerToTest.CreateAccount(testAccountType, testLastName, testFirstName, testMailAdresse, testLogin, testPwd);

            Assert.That(result, Is.Not.Null);
            Assert.That(resultStudent, Is.Not.Null);
            // Assert.That(testLastName, Is.EqualTo(resultStudent.LastName));
            //    Assert.That(expectedFirstName, Is.EqualTo(resultModel.FirstMidName));



        }








    }
}
