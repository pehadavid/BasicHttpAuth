using System;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace BasicHttpAuth
{
    public class BasicAuthMiddleware : OwinMiddleware
    {
        public BasicAuthMiddleware(OwinMiddleware next) : base(next)
        {

        }



        public override async Task Invoke(IOwinContext context)
        {
            bool setunauth = true;

            var header = context.Request.Headers.Get("Authorization");

            if (!String.IsNullOrWhiteSpace(header))
            {
                var authHeader = AuthenticationHeaderValue.Parse(header);

                if ("Basic".Equals(authHeader.Scheme,
                                         StringComparison.OrdinalIgnoreCase))
                {
                    string parameter = Encoding.UTF8.GetString(
                                          Convert.FromBase64String(
                                                authHeader.Parameter));
                    var parts = parameter.Split(':');

                    string userName = parts[0];
                    string password = parts[1];

                    if (Settings.IsUserPassValid(userName, password))
                    {
                        await Next.Invoke(context);
                        setunauth = false;
                    }
                }
            }

            if (setunauth)
            {
                context.Response.Headers.Add("WWW-Authenticate", new string[] { "Basic" });
                context.Response.StatusCode = 401;
            }

        }
    }
}
