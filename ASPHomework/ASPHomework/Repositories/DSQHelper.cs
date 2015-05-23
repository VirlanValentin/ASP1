using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using DataBase;

namespace ASPHomework.Repositories
{
    public class DSQHelper
    {
        #region Subdomain
        //SubdomainHelper
        //GetAll
        public static List<Subdomains> GetAllSubdomains()
        {
            using (var context = new ervinEntities())
            {
                return context.Subdomains.ToList();
            }
        }
  
        //Add
        public static void AddSubdomain(Subdomains subdomain)
        {
            using (var context = new ervinEntities())
            {
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
        public static void AddQuestion(Questions question)
        {
            using (var context = new ervinEntities())
            {
                context.Questions.Add(question);
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