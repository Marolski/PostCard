using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostCard.Models
{
    public class UserDb
    {
        public int ID { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Verified { get; set; }
        public DateTime Date { get; set; }

    }
}