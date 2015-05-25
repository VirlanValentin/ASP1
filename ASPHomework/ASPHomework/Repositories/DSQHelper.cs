using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPHomework.Models;
using DataBase;

namespace ASPHomework.Repositories
{
    public class DSQHelper
    {

        #region Domain

        public static void AddDomain(string name)
        {
            using (var context =  new ervinEntities())
            {
                var domain = new Domains {DomainName = name};
                context.Domains.Add(domain);
                context.SaveChanges();
            }
        }

        public static IEnumerable<SelectListItem> GetAllDomains()
        {
           // var domainModels = new List<DomainModel>();
            IEnumerable<SelectListItem> dom;
            using (var context = new ervinEntities())
            {
                var aux = context.Domains.Where(x => x.Id > 0).ToList();
                dom = aux.Select(d => new SelectListItem {Text = d.DomainName, Value = d.DomainName});
            }
            return dom;
        }

        #endregion


        #region Subdomain
        //SubdomainHelper
        //GetAll
        public static IEnumerable<SelectListItem> GetAllSubdomains()
        {
            IEnumerable<SelectListItem> subdom;
            using (var context = new ervinEntities())
            {
                var aux = context.Subdomains.Where(x => x.Id > 0).ToList();
                subdom = aux.Select(d => new SelectListItem { Text = d.SubdomainName, Value = d.SubdomainName });
            }

            return subdom;
        }

        //Add
        public static void AddSubdomain(SubdomainModel subdomainModel)
        {
            using (var context = new ervinEntities())
            {
                var subdomain = new Subdomains(){ SubdomainName = subdomainModel.SubdomainName };
                var domain = context.Domains.First(x => x.DomainName == subdomainModel.DomainName);
                subdomain.IdDomain = domain.Id;
                context.Subdomains.Add(subdomain);
                context.SaveChanges();
            }
        }
        //Edit
        public static void EditSubdomain(Subdomains subdomain)
        {
            using (var context = new ervinEntities())
            {
                var selectedSubdomain = context.Subdomains.First(x => x.Id == subdomain.Id);
                selectedSubdomain.IdDomain = subdomain.IdDomain;
                selectedSubdomain.SubdomainName = subdomain.SubdomainName;
                context.SaveChanges();
            }
        }
        //Delete
        public static void DeleteSubdomain(int id)
        {
            using (var context = new ervinEntities())
            {
                var selectedSubdomain = context.Subdomains.FirstOrDefault(x => x.Id == id);
                context.Subdomains.Remove(selectedSubdomain);
                context.SaveChanges();
            }
        }
        #endregion

        #region Question
        //GetAll
        public static List<Questions> GetAllQuestions()
        {
            using (var context = new ervinEntities())
            {
                return context.Questions.ToList();
            }
        }
        //GetAll qestions of a subdomain
        public static List<Questions> GetAllQuestionsOfASpecificSubdomain(int id)
        {
            using (var context = new ervinEntities())
            {
                return context.Questions.Where(x => x.IdSubdomain == id).ToList();
            }
        }
        //Add
        public static void AddQuestion(QuestionsModel question)
        {
            using (var context = new ervinEntities())
            {
                var sdId = context.Subdomains.FirstOrDefault(x => x.SubdomainName == question.SubdomainName).Id;

                var q = new Questions()
                {
                    Question = question.Question,
                    Answers = question.Answer1 + "~" + question.Answer2 + "~" + question.Answer3 + "~" + question.Answer4 + "~" + question.Answer5,
                    Argumentation = question.Argumentation,
                    TypeOfQuestion = question.TypeOfQuestion,
                    RightAnswer = question.RightAnswer,
                    IdSubdomain = sdId
                };

                context.Questions.Add(q);
                context.SaveChanges();
            }
        }

        //Edit
        public static void EditQuestion(Questions question)
        {
            using (var context = new ervinEntities())
            {
                var selectedquestion = context.Questions.First(x => x.Id == question.Id);
                selectedquestion.Question = question.Question;
                selectedquestion.Answers = question.Answers;
                selectedquestion.RightAnswer = question.RightAnswer;
                selectedquestion.Argumentation = question.Argumentation;
                selectedquestion.TestQuestions = question.TestQuestions;
                selectedquestion.IdSubdomain = question.IdSubdomain;
                context.SaveChanges();
            }
        }

        //Delete
        public static void DeleteQuestion(int id)
        {
            using (var context = new ervinEntities())
            {
                var selectedquestion = context.Questions.FirstOrDefault(x => x.Id == id);
                context.Questions.Remove(selectedquestion);
                context.SaveChanges();
            }
        }

        #endregion
    }
}