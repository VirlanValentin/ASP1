using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPHomework.Models
{
    public class QuestionsModel 
    {
        [Required]
        [DisplayName("Intrebare")]
        public string Question { get; set; }

        [Required]
        [DisplayName("Raspunsul 1")]
        public string Answer1 { get; set; }
        [Required]
        [DisplayName("Raspunsul 2")]
        public string Answer2 { get; set; }
        [Required]
        [DisplayName("Raspunsul 3")]
        public string Answer3 { get; set; }

        [DisplayName("Raspunsul 4")]
        public string Answer4 { get; set; }

        [DisplayName("Raspunsul 5")]
        public string Answer5 { get; set; }

        [Required]
        [DisplayName("Raspunsul corect")]
        public int RightAnswer { get; set; }
        [Required]
        [DisplayName("Argumentare")]
        public string Argumentation { get; set; }
        [Required]
        [DisplayName("Intrebare cu raspuns multiplu?")]
        public bool TypeOfQuestion { get; set; }

        [DisplayName("Subdomeniu")]
        public string SubdomainName { get; set; }
    }
}