using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthenticationAndAuthorization.Models
{
    public class Dept
    {
        [Key]
        public int DepartmentId { get; set; }

        public String DepartmentName { get; set; }

        public string Username { get; set; }
        

    }
}