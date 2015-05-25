using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace ASPHomework.Models
{
    public class SubdomainModel
    {
        [Required]
        [DisplayName("Subdomeniu")]
        public string SubdomainName { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public int IdDomain { get; set; }

        [DisplayName("Domeniu")]
        public string DomainName { get; set; }
        
    }
}