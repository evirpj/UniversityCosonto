using ContosoUniversity.Tests.Tools;
using ContosoUniversity.Controllers;
using ContosoUniversity.DAL;
using ContosoUniversity.Models;
using Moq;
using NUnit.Framework;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


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
        public void LoginSuccess()
        {
            

        }




        [Test]
        public void LoginFail()
        {

        }

        [Test]
        public void SuccesfulLogout()
        {

        }

    }
}
