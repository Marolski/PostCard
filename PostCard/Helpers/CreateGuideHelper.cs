using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostCard.Helpers
{
    public class CreateGuideHelper
    {
        public string CreateGuide()
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string guide = null;
            for (int i = 0; i < 15; i++)
            {
                int x = random.Next(chars.Length);
                guide += chars[x];
            }
            return guide;
        }
    }
}