using Layoutmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Layoutmvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult submit(Login_table l)
        {
            if (ModelState.IsValid)
            {
                string username = Request.Form["Login"];
                string pwd = Request.Form["password"];
                bool res = DBOperations.valid(username, pwd);
                if (res == true)
                {
                    return View();
                }

                else
                {
                    return View("Index");
                }
            }
            else
                return View("Index");
        }
    }
}