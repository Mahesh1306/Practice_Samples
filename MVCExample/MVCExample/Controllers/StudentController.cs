using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCExample.Models;

namespace MVCExample.Controllers
{

    public class StudentController : Controller
    {
                List<Student> studentList = new List<Student>{
                new Student() { StudentId = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentId = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentId = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
                new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 } ,
                new Student() { StudentId = 4, StudentName = "Rob" , Age = 19 }
                 };
            
        public ActionResult Details(int studentId)
        {
            return View(studentList);
        }
        public ActionResult ListOut(int studId)
        {
            var list = studentList.OrderBy(x => x.StudentId).ToList();
            return View(list);
        }
      
    }


}