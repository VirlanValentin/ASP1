using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataBase;

namespace DBOperations
{
   public static class UsersHelper
    {
       public static void AddHint()
        {
            var hint = new Hints {Question = "How old are you?"};
            using (var context = new ervinEntities())
            {
                context.Hints.Add(hint);
                context.SaveChanges();
            }
       }
    }
}
