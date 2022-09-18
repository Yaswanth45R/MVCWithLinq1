using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWithLinq1.Models;

namespace MVCWithLinq1.Controllers
{
    public class StudentController : Controller
    {
        StudentDAL obj = new StudentDAL();
        public ViewResult DisplayStudents()
        {
            return View(obj.GetStudents(true));
        }
        public ViewResult DisplayStudent(int Sid)
        {
            return View(obj.GetStudent(Sid,true));
        }
        [HttpGet]
        public ViewResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public RedirectToRouteResult AddStudent(Student student)
        {
            obj.AddStudent(student);
            return RedirectToAction("DisplayStudents");
        }
    }
}