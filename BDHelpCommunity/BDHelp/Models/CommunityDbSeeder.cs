using FInal_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BDHelp.Models
{
    public class CommunityDbSeeder:DropCreateDatabaseIfModelChanges<CommunityDbContext>
    {
        protected override void Seed(CommunityDbContext context)
        {
            base.Seed(context);
            Category category = new Category()
            {
                CategoryName = "Education"
            };
            context.Categories.Add(category);
           

        }
    }
}