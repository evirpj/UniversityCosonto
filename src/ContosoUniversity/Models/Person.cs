using ContosoUniversity.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContosoUniversity.Models
{
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
        //Email 
        [Required]
        public string MailAdresse { get; set; }
        //Login
        [Required]
        [RegularExpression("[a-zA-Z0-9]*", ErrorMessage = "Enter only letters and/or numbers.")]
        public string Login { get; set; }
        //Password
        [Required]
        [RegularExpression("[a-zA-Z0-9]*", ErrorMessage = "Enter only letters and/or numbers.")]
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