using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataBase;

namespace ASPHomework.Repositories
{
    public class DSQHelper
    {
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

        public static void DeleteSubdomain(int id)
        {
            using (var context = new ervinEntities())
            {
                var selectedSubdomain = context.Subdomains.FirstOrDefault(x => x.Id == id);
                context.Subdomains.Remove(selectedSubdomain);
                context.SaveChanges();
            }


        }
    }
}