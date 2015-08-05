using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace BasicHttpAuth
{
    internal static class Settings
    {
        public static string UserName => WebConfigurationManager.AppSettings["basicAuth:username"] ?? "";
        public static string Password => WebConfigurationManager.AppSettings["basicAuth:pass"] ?? "";

        /// <summary>
        /// Validate username & password according to the web.config appsettings section.
        /// </summary>
        /// <param name="userName">username provided</param>
        /// <param name="password">password provided. Must be 64 decoded</param>
        /// <returns></returns>
        public static bool IsUserPassValid(string userName, string password)
        {
            return userName.Equals(Settings.UserName, StringComparison.InvariantCultureIgnoreCase) &&
                   password.Equals(Settings.Password, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
