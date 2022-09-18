using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWithLinq1.Models
{
    public class StudentDAL
    {
        MVCDBDataContext context = new MVCDBDataContext();
        public List<Student> GetStudents(bool? Status)
        {
            List<Student> students;
            try
            {
                if (Status != null)
                {
                    students = (from s in context.Students where s.Status == Status select s).ToList();
                }
                else
                {
                    students = (from s in context.Students select s).ToList();
                }
                return students;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Student GetStudent(int Sid, bool? Status)
        {
            Student student;
            try
            {
                if (Status == null)
                {
                    student = (from s in context.Students where s.Sid == Sid select s).Single();
                }
                else
                {
                    student = (from s in context.Students where s.Sid == Sid && s.Status == Status select s).Single();
                }
                return student;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void AddStudent(Student student)
        {
            try
            {
                context.Students.InsertOnSubmit(student);
                context.SubmitChanges();    
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}