using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDHelp.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        [AllowHtml]
        public string ArticleTitle { get; set; }
        [AllowHtml]
        public string ArticleBody { get; set; }

    }
}