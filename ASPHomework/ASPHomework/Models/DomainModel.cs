using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPHomework.Repositories;

namespace ASPHomework.Models
{
    public class DomainModel
    {
        public IEnumerable<SelectListItem> DomainName
        {
            get { return DSQHelper.GetAllDomains(); }
            set { }
        }
    }
}