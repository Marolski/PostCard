using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PostCard.Helpers
{
    public class HashHelper
    {
        public static string Hash(string source)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] bytes = crypt.ComputeHash(Encoding.UTF8.GetBytes(source));
            foreach (byte theByte in bytes)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();

        }
    }
}