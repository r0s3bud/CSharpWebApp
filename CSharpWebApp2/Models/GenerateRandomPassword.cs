using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace CSharpWebApp2.Models
{
    public class GenerateRandomPassword
    {
        private static Random random = new Random();
        public string GeneratePassword()
        {
            const int PASSWORD_LENGTH = 12;
            const int NUMBER_OF_NON_ALPHANUMERIC_CHARACTESRS = 4;

            string PASSWORD = Membership.GeneratePassword(PASSWORD_LENGTH, NUMBER_OF_NON_ALPHANUMERIC_CHARACTESRS);

            return (PASSWORD);
        }
    }
}