using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MVCExample.Models;

namespace MVCExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration configuration;
        private ContextModel _context;

        public HomeController(ILogger<HomeController> logger,IConfiguration _configuration,ContextModel contextModel)
        {
            _logger = logger;
            configuration = _configuration;
            _context = contextModel;
        }
        public IActionResult Data()
        {
            List<Student> student = new List<Student>();
            student = _context.Student.ToList();
            _logger.LogInformation("Some goes wrong");
            return View(student);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _context.Student.Where(s => s.StudentId == id).FirstOrDefault();
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            var data = _context.Student.Where(s => s.StudentId == student.StudentId).FirstOrDefault(); ;
            if (data != null)
            {
                data.StudentName = student.StudentName;
                data.Age = student.Age;
                data.Gender = student.Gender;
                _context.SaveChanges();
            }
            return RedirectToAction("Data", "Home");
        }
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Student student)
        {
            _context.Student.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Data", "Home");
        }
        [HttpGet]
        public ActionResult CheckForDuplicateName(string stuName)
        {
            int result = 0;
            bool con = _context.Student.Any(s => s.StudentName.Equals(stuName));
            if (_context.Student.Any(s=>s.StudentName.Equals(stuName)))
            {
                result = 1;
            }
            return Json(result);
        }
        [HttpPost]
        public ActionResult SaveRecord(Student student)
        {
            _context.Student.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Data","Home");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _context.Student.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Data", "Home");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _context.Student.Where(s => s.StudentId == id).FirstOrDefault();
            return View(data);

        }
        public IActionResult Delete(Student student)
        {
            var data = _context.Student.Where(s => s.StudentId == student.StudentId).FirstOrDefault();
            _context.Student.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Data","Home");
        }
        public async Task<IActionResult> Find(int? id)
        {
            Student data = await _context.Student.FindAsync(id);
            return View(data);
        }
        public IActionResult Details(int id)
        {
            var data = _context.Student.Where(s => s.StudentId == id).FirstOrDefault();
            return View(data);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
