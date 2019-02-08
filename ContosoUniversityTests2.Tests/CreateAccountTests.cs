using ContosoUniversityTests2.Controllers;
using ContosoUniversityTests2.DAL;
using ContosoUniversityTests2.Models;
using System;
using ContosoUniversity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContosoUniversityTests2.Tests
{
    [TestClass]
    public class CreateAccountTests
    {
        [TestMethod]
        public void MethodeTestee_EtatInitial_EtatAttendu()
        {
            CreateAccount createAccount = new CreateAccount();
          
            Assert.AreEqual(EtatAttendu, resultat,"message error");
        }
    }
}
