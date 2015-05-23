using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPHomework.Models;
using ASPHomework.Repositories;


namespace ASPHomework.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

         [HttpPost]
         [ValidateAntiForgeryToken]
        public ActionResult Register(UserRegister user)
        {
            if (ModelState.IsValid)
            {
                UserHelper.AddUser(user);
                    ModelState.Clear();
                    user = null;
                    ViewBag.Message = "Registration Successfully Done";
                
            }
            return View(user);
        }
    }
}