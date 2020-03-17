using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Layoutmvc.Models
{
    public class DBOperations
    {
        static DemoEntities d = new DemoEntities();
        public static bool valid(string login,string pwd)
        {
            var LE=(from L in d.Login_tables
                   where L.Login==login && L.password==pwd
                   select L).FirstOrDefault();
            if (LE != null)
            {
                return true;
            }
            else
                return false;

        }
        public static List<EMPDATA> GetAll()
        {
            var LE = from E1 in d.EMPDATAs
                     select E1;
            return LE.ToList();

        }
        public static EMPDATA edit(int empno)//or use extractemp method
        {
            EMPDATA E = (from L in d.EMPDATAs
                         where L.EMPNO == empno
                         select L).FirstOrDefault();
            return E;
        }
        public static string updatedata(int empno, EMPDATA emp)
        {
            var le = from l in d.EMPDATAs
                     where l.EMPNO == empno
                     select l;
            foreach (var item in le)
            {
                item.JOB = emp.JOB;
                item.MGR = emp.MGR;
                item.SAL = emp.SAL;
                item.COMM = emp.COMM;
                item.DEPTNO = emp.DEPTNO;
            }
            d.SaveChanges();
            return "1 row updated";
        }
        public static string DelEmp(int empno)
        {
            var le = from L in d.EMPDATAs
                    where L.EMPNO == empno
                    select L;
            d.EMPDATAs.Remove(le.First());
            d.SaveChanges();
            return "1 Row Deleted";
        }
        public static string InsertEmp(EMPDATA E)
        {
            try
            {
                d.EMPDATAs.Add(E);
                d.SaveChanges();
            }
            catch (DbUpdateException p)
            {
                SqlException ex = p.GetBaseException() as SqlException;
                if (ex.Message.Contains("FK_EMPDATA"))
                {
                    return "No proper deptno";
                }
                else if (ex.Message.Contains("EMP_PK"))
                {
                    return " no duplicate Empno ";
                }
                else
                    return "error occured";
            }

            return "1 row inserted";
        }
    }
}