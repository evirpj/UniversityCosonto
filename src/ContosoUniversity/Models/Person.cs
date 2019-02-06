using ContosoUniversity.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContosoUniversity.Models
{
    public enum DiscriminatorOptions
    {
        Student = 1,
        Instructor = 2,
    }

    public abstract class Person
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        //Email (expressions regulieres a ajouter)
        public string MailAdresse { get; set; }

        //Login
        public string Login { get; set; }

        //Password
        public string Password { get; set; }



        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }
    }
}