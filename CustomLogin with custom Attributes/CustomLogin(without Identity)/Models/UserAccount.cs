using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CustomLogin_without_Identity_.Shared;

namespace CustomLogin_without_Identity_.Models
{
    public class UserAccount
    {
       [Key]
        public int UserId { set; get; }

        [Display(Name = "Username")]
       // [Index(IsUnique =true)]
       [UsernameNotExists]
        [Required(ErrorMessage ="Username Required")]
        public string UserName { set; get; }

        [Required(ErrorMessage ="First Name is required")]
        public string FirstName { set; get; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { set; get; }
        [Required(ErrorMessage = "Email Name is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [MailNotExists]
        // [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage ="Please enter an valid Email.")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Password Name is required")]
        [DataType(DataType.Password)]
        public string Password { set; get; }
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Please confirm your password")]
        public string ConfirmPassword { set; get; }
      
    }
}