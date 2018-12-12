using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EntitySetupApp.Models
{
    public class MyDbContext : IdentityDbContext<AppUser>
    {
        public System.Data.Entity.DbSet<EntitySetupApp.Models.LoginModel> LoginModels { get; set; }
    }
}