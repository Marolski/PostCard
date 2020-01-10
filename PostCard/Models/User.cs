using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PostCard.Models
{
    public class User
    {
        public int ID { get; set; }
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        [RegularExpression("^[a-zA-Z0-9].{5,15}$",ErrorMessage = "Username can be from 5 to 15 characters")]
        public string Nick { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "Password must contain uppercase letters and number")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped] // Nie wysyła do bazy
        public string ConfirmPassword { get; set; }

        public bool Verified { get; set; }

        public DateTime Date { get; set; }

        public string Hash { get; set; }
    }
}