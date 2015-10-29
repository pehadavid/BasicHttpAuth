# Quick Start Tutorial

* Install BasicHttpAuth from NuGet (use VS Nuget GUI or Install-Package BasicHttpAuth)
* Check project dependencies : You should have Owin, Microsoft.Owin and Microsoft.Owin.Host.SystemWeb
* Change username and password in your web.config (appSettings > basicAuth:username and basicAuth:pass)
* Make sure that your project has an Owin Startup Class and add the BasicAuthMiddleware to your Owin pipeline
* Also be sure to add it before other autentication middleware you might be using like for example: `app.UseCookieAuthentication`

```C#
[assembly: OwinStartupAttribute(typeof(SampleProject.Startup))]
namespace SampleProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          app.Use(typeof (BasicAuthMiddleware));
        }
    }
}
````