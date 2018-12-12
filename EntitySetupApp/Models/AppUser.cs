using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EntitySetupApp.Models
{
    public class AppUser : IdentityUser
    {
        public string AstrologicalSign { get; set; }
        public DateTime Birthday { get; set; }
    }
}