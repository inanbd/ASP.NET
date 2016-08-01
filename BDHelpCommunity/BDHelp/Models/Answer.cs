using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FInal_Project.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        [Required(ErrorMessage ="Answer text can't be empty!!")]
        public string AnswerText { get; set; }
        public int AnswerRating { get; set; }
        [Required(ErrorMessage = "Answer date can't be empty!!")]
        public DateTime AnswerDate { get; set; }
        [ForiegnKey]
        public int QuestionNo { get; set; }
        public UserQuestion QuestionId { get; set; }
        public UserModel UserId { get; set; }
    }
}