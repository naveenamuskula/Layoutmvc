using Layoutmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Layoutmvc.Controllers
{
    public class CheckBoxController : Controller
    {
        // GET: CheckBox
        List<EMPDATA> l = null;
        public ActionResult Index()
        {
            ViewBag.S = DBOperations.GetAll();
            return View();
        }
        public ActionResult SubmitBtn()
        {
            var empno = Request.Form.Get("chk");
            l = DBOperations.GetAll();
            List<EMPDATA> EL = new List<EMPDATA>();
            foreach(var i in l)
            {
                if(empno.Contains(i.EMPNO.ToString()))
                {
                    EL.Add(i);    
                }
                
            }
            ViewBag.S = EL;
            return View();
        }
    }
}