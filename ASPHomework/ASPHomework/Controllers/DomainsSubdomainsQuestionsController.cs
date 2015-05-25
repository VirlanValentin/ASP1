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
        public ActionResult Subdomain()
        {
            ViewBag.domains = DSQHelper.GetAllDomains().ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Subdomain(SubdomainModel sm, string domains)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                sm.DomainName = domains;
                DSQHelper.AddSubdomain(sm);
                return RedirectToAction("Subdomain");
            }

            ViewBag.domains = DSQHelper.GetAllDomains().ToList();

            return View(sm);
        }

        public ActionResult Question()
        {
            ViewBag.subdomains = DSQHelper.GetAllSubdomains().ToList();            
            return View();
        }

        [HttpPost]
        public ActionResult Question(QuestionsModel qm, string subdomains)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                qm.SubdomainName = subdomains;
                DSQHelper.AddQuestion(qm);
                return RedirectToAction("Question");
            }

            ViewBag.subdomains = DSQHelper.GetAllSubdomains().ToList();   

            return View(qm);
        }
    }
}