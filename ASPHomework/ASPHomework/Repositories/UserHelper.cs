using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPHomework.Models;
using DataBase;

namespace ASPHomework.Repositories
{
    public class UserHelper
    {
        public static void AddUser(UserRegister userModel)
        {
            var user = new Users
            {
                FirstName = userModel.FirstName,
                SecondName = userModel.SecondName,
                Email = userModel.Email,
                Password = userModel.Password,
                HintId = 1,
                HintAnswer = "21",
                isAdmin = false
            };
            using (var context = new ervinEntities())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
        public static void AddHint()
        {
            var hint = new Hints { Question = "How old are you?" };
            using (var context = new ervinEntities())
            {

                context.Hints.Add(hint);
                context.SaveChanges();
            }
        }
    }
}