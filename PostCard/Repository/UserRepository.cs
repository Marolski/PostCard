using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PostCard.Database;
using PostCard.Models;

namespace PostCard.Repository
{
    public class UserRepository
    {
        UserContext _context = new UserContext();
        public string GetGuidByUsername(string nick)
        {
            return _context.UserDb.FirstOrDefault(x => x.Nick == nick).Guide;
        }
        public User GetUserByUsername(string nick)
        {
            return _context.UserDb.FirstOrDefault(x => x.Nick == nick);
        }
        public User GetUserByEmail(string Email)
        {
            return _context.UserDb.FirstOrDefault(x => x.Email == Email);
        }
    }
}