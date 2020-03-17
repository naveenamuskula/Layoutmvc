using Layoutmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Layoutmvc.Controllers
{
    public class EMPController : Controller
    {
        // GET: EMP
        public ActionResult Index()
        {
            List<EMPDATA> L = DBOperations.GetAll();
            return View(L);
        }
        public ActionResult Create()
        {
            return View();
        }
        
        public ActionResult Insert(EMPDATA E)
        {
            ViewBag.msg = DBOperations.InsertEmp(E);
            return View("Create");
        }
       
        public ActionResult Edit(int id)
        {
            EMPDATA L = DBOperations.edit(id);
            return View(L);
        }
        public ActionResult Editbtn(EMPDATA P)
        {
            int empno = int.Parse(Request.Form["EMPNO"]);
            string s = DBOperations.updatedata(empno, P);
            ViewBag.msg = s;
            return View("Edit");
        }
        public ActionResult Delete(int id)
        {
            string s = DBOperations.DelEmp(id);
            ViewBag.msg = s;
            return RedirectToAction("Index");
        }
    }
}