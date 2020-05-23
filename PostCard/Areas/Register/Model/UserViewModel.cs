using PostCard.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.Web.Mvc.CompareAttribute;

namespace PostCard.Models
{
    public class UserViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is require")]
        [RegularExpression("^(?=.{5,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$", ErrorMessage = "Username can be from 5 to 15 characters and exclude special symbols")]
        public string Nick { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is require")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "Password must contain uppercase letters and number")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is require")]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Terms and Conditions")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Musisz zaackeptować warunki regulaminu")]
        public bool TermsAndConditions { get; set; }

        [Required(ErrorMessage = "Country code is require")]
        [Display(Name = "Country code")]
        public CountryCodeEnum CountryCode { get; set; }

    }
}