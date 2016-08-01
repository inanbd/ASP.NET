using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FInal_Project.Models
{
    public class UserQuestion
    {
        [Key]
        public int QuestionId { get; set; }
        [Required(ErrorMessage ="Question Header can't be empty!")]
        [DisplayName("Question Title")]
        public string QuestionHeader { get; set; }
        [DisplayName("Question Body")]
        
        public string QuestionText { get; set; }
        public int QuestionRating { get; set; }
        public int Unlike { get; set; }
        public int IsSatisfied { get; set; }
        [Required(ErrorMessage = "Question Date can't be empty!")]
        public DateTime QuestionDate { get; set; }
        public int CategoryId { get; set; }
      
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public List<Answer> Answers { get; set; }
        public List<UserModel> Users { get; set; }
    }
}