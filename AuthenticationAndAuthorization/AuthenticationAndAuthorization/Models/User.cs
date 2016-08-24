using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthenticationAndAuthorization.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Username { set; get; }

        public string Password { get; set; }

        public String Role { get; set; }
    }
}