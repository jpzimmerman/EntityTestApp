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
using EntitySetupApp.Models;


namespace EntitySetupApp.Data
{
    public class AppUserDbContext : IdentityDbContext<AppUser>
    {
        public AppUserDbContext(string connectionString) : base(connectionString) { }
    }
}