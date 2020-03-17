using Layoutmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Layoutmvc.Controllers
{
    public class BindingController : Controller
    {
        // GET: Binding
        [ActionName("Example")]
        public ActionResult Sample()
        {
            return View("Sample");
        }
        public ActionResult Index()
        {
            return View();
        }
        //2)primitive binding
        //getting the details by entering the id in the address bar
        public ActionResult Update(int id)//"id" here refers to the primary key ,we are using
        {
            return View("Index", DBOperations.edit(id)); 
        }
        //3)binding to complex type---used in the projects
        //[HttpPost]
        //public ActionResult Update(EMPDATA E)
        //{
        //    return View();
        //}
        //4)Basic Type(not suggested)`
        //[HttpPost]
        //public ActionResult Update(int EMPNO,string ENAME,string JOB,int MGR,DateTime HIREDATE,int SAL,int COMM,int DEPTNO)
        //{
        //    return View();
        //}
        //5)Form Collections: will have the values of the controls
        //[HttpPost]
        //public ActionResult Update(FormCollection f)
        //{
        //    int eno = int.Parse(f["EMPNO"]);
        //    string ename = f["ENAME"];
        //    return View();
        //}
        //6)using BIND(it has two attributes:Include,Exclude)
        //only the changed values of ename,job,mgr will be shown other fields will be null
        //[HttpPost]
        //public ActionResult Update([Bind(Include="ENAME,JOB,MGR")]EMPDATA E)
        //{
        //    return View();
        //}
        [HttpPost]
        public ActionResult Update([Bind(Exclude = "ENAME,JOB,MGR")]EMPDATA E)
        {
            return View();
        }
    }
}