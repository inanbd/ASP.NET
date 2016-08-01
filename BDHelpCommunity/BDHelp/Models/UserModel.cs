using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FInal_Project.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage ="User Name can't be empty!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password can't be empty!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password can't be empty!")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Password can't be empty!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string UserPhone { get; set; }
        [Required(ErrorMessage = "User City can't be empty!")]
        public string UserCity { get; set; }
        [Required(ErrorMessage = "Address can't be empty!")]
        public string UserAddress { get; set; }
        public int UserRating { get; set; }
        public string UserType { get; set; }
        [DisplayName("Remember me ?")]
        public bool RememberMe { get; set; }
        
       
      
        public List<UserQuestion> UserQuestions { get; set; }
        public List<Answer> UserAnswers { get; set; }


    }
}