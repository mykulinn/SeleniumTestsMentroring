using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests.Data
{
    public static class CommonTestData
    {
        public const string AdminEmail = "admin@fluxday.io";
        public const string Password = "password";

        public static string UrlForLoginPage
        {
            get
            {
                return "https://app.fluxday.io/users/sign_in";
            }
        }
    }
}
