using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPHomework.Models;
using ASPHomework.Repositories;

namespace ASPHomework.Controllers
{
    public class DomainsSubdomainsQuestionsController : Controller
    {
        // GET: DomainsSubdomainsQuestions
        public ActionResult Index()
        {
            ViewBag.domains = DSQHelper.GetAllDomains().ToList();

            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index(SubdomainModel sm, string domains)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                sm.DomainName = domains;
                DSQHelper.AddSubdomain(sm);
                return RedirectToAction("Index");
            }

            ViewBag.domains = DSQHelper.GetAllDomains().ToList();

            return View(sm);
        }

        public ActionResult Question()
        {
         //   DSQHelper.AddDomain("Capitole speciale .NET");
            
            return View();
        }
    }
}