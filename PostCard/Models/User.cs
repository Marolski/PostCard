using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PostCard.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        public string Nick { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool Verified { get; set; }
        [Required]
        public DateTime Date { get; set; }

    }
}