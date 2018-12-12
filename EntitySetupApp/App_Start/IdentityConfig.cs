using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using EntitySetupApp.Data;
using EntitySetupApp.Models;

namespace EntitySetupApp
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DevBuildMovieDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            app.CreatePerOwinContext(() => new AppUserDbContext(connectionString));

            //app.CreatePerOwinContext(() => new Models. DevBuildMovieDB1());

            app.CreatePerOwinContext<UserStore<AppUser>>((options, context) => new UserStore<AppUser>(context.Get<AppUserDbContext>()));

            app.CreatePerOwinContext<UserManager<AppUser>>((options, context) => new UserManager<AppUser>(context.Get<UserStore<AppUser>>()));
            //app.CreatePerOwinContext<RoleManager<AppRole>>(AppRole.Create);
            app.CreatePerOwinContext<RoleManager<AppRole>>((options, context) =>
                new RoleManager<AppRole>(
                    new RoleStore<AppRole>(context.Get<AppUserDbContext>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Identity/Login"),
                //LoginPath = new Microsoft.Owin.PathString(),
            });
        }
        

    }
}