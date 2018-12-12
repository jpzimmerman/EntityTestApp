using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EntitySetupApp.Models
{
    public class LoginModel
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}