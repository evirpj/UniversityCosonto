using ContosoUniversity.DAL;
using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Tests.Tools
{
    public class EntityGenerator
    {
        private readonly SchoolContext dbContext;

        public EntityGenerator(SchoolContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Student CreateStudent(string lastname, string firstname)
        {
            var student = new Student()
            {
                LastName = lastname,
                FirstMidName = firstname
            };

            this.dbContext.Students.Add(student);
            dbContext.SaveChanges();
            return student;
        }


        // A student generator for testing the login controller 
        public Student CreateStudentForLogin(string lastname, string firstname, string login, string password, string mailadresse, DateTime enrollmentdate)
        {
            var student = new Student()
            {
                LastName = lastname,
                FirstMidName = firstname,
                Login = login,
                Password = password,
                MailAdresse = mailadresse,
                EnrollmentDate = DateTime.Parse(DateTime.Now.ToString())


            };

            this.dbContext.Students.Add(student);
            dbContext.SaveChanges();
            return student;
        }


        // An instructor generator for testing the login controller 
        public Instructor CreateInstructorForLogin(string lastname, string firstname, string login, string password, string mailadresse, DateTime enrollmentdate)
        {
            var instructor = new Instructor()
            {
                LastName = lastname,
                FirstMidName = firstname,
                Login = login,
                Password = password,
                MailAdresse = mailadresse,
                HireDate = DateTime.Parse(DateTime.Now.ToString())


            };

            this.dbContext.Instructors.Add(instructor);
            dbContext.SaveChanges();
            return instructor;
        }

    }
}
