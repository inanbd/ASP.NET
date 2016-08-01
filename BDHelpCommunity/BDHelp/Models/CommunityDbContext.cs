using FInal_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BDHelp.Models
{
    public class CommunityDbContext:DbContext
    {
        public DbSet<Answer> Answers{ get; set; }
        public DbSet<UserModel> UserModels { get; set; }

        public DbSet<UserQuestion> UserQuestions { get; set; }
        public DbSet<Category> Categories { get; set; }
       



    }
}