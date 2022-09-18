using System;
using System.Collections.Generic;
using System.IO;
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
        public RedirectToRouteResult AddStudent(Student student,HttpPostedFileBase SelectedFile)
        {
            if(SelectedFile != null)
            {
               string PhysicalPath =  Server.MapPath("~/Uploads/");
                if (!Directory.Exists(PhysicalPath))
                {
                    Directory.CreateDirectory(PhysicalPath);
                }
                SelectedFile.SaveAs(PhysicalPath + SelectedFile.FileName);
            }
            student.Photo = SelectedFile.FileName;
            student.Status = true;
            obj.AddStudent(student);
            return RedirectToAction("DisplayStudents");
        }
    }
}