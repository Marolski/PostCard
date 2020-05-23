using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PostCard.Helpers
{
    public class StringGenerator
    {
        public static string RandomString(int length)
        {
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var builder = new StringBuilder();
            Random random = new Random();

            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }
    }
}