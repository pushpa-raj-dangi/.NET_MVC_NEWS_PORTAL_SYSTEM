using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Helpers
{
    public class GenerateUserName
    {
        public static string RenderUserName(string input)
        {
            if (input.Length > 0)
            {

            var index =input.IndexOf('@');

            return input.Substring(0, index);
            }
            return "";
        }
    }
}
