using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CustomLogin_without_Identity_.Models;

namespace CustomLogin_without_Identity_.Shared
{
    public class UsernameNotExists : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var owner = validationContext.ObjectInstance as UserAccount;
            if (owner == null) return new ValidationResult("Model is empty");
            OurDbContext db = new OurDbContext();
            var user = db.userAccounts.FirstOrDefault(u => u.UserName == (string)value && u.UserId != owner.UserId);

            if (user == null)
                return ValidationResult.Success;
            else
                return new ValidationResult("Username already exists");
        }
    }
}