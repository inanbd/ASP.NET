using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserRoles.Models
{
    public class Account
    {
        [Display(Name ="Username")]
        public string Username { set; get; }
        [Display(Name = "Password")]
        public String Password { get; set; }

        public String[] Roles { get; set; }

    }
}