using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AuthenticationAndAuthorization.Models
{
    public class EDBContext :DbContext
    {

        public DbSet<User> Users { set; get; }

        public DbSet<Dept> Departments { set; get; }

    }
}