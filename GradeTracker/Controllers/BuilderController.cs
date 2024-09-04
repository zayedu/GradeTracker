using Microsoft.AspNetCore.Mvc;
using GradeTracker.Models;

namespace GradeTracker.Controllers
{
    public class BuilderController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Build(string courseName)
        {
            Course course = new Course();
            switch (courseName)
            {
                case "3DB3" :
                    course.Assignments = new List<Assignment>
                    {
                        new Assignment() { Name = "Assignment 1", Mark = 0, Weight = 12 },
                        new Assignment() { Name = "Assignment 2", Mark = 0, Weight = 14 },
                        new Assignment() { Name = "Assignment 3", Mark = 0, Weight = 14 }
                    };
                    course.Name = "SFWRENG 3DB3";
                    course.Final = new Final() { Name = "Final Exam", Mark = 0, Weight = 40 };
                    course.Midterms = new List<Midterm>
                    {
                        new Midterm() { Name = "Midterm 1", Mark = 0, Weight = 20 }
                    };
                    return View("Course", course);
                
                case "3O03" :
                    course.Assignments = new List<Assignment>
                    {
                        new Assignment() { Name = "Assignment 1", Mark = 0, Weight = 10 },
                        new Assignment() { Name = "Assignment 2", Mark = 0, Weight = 10 },
                        new Assignment() { Name = "Assignment 3", Mark = 0, Weight = 10 }
                    };
                    course.Name = "SFWRENG 3O03";
                    course.Final = new Final() { Name = "Final Exam", Mark = 0, Weight = 40 };
                    course.Midterms = new List<Midterm>
                    {
                        new Midterm() { Name = "Midterm 1", Mark = 0, Weight = 30 }
                    };
                    return View("Course", course);
                
                case "3MX3" :
                    course.Assignments = new List<Assignment>();
                    course.Name = "SFWRENG 3MX3";
                    course.Final = new Final() { Name = "Final Exam", Mark = 0, Weight = 60 };
                    course.Midterms = new List<Midterm>
                    {
                        new Midterm() { Name = "Midterm 1", Mark = 0, Weight = 20 },
                        new Midterm() { Name = "Midterm 2", Mark = 0, Weight = 20 }

                    };
                    return View("Course", course);
                
                case "3BB4" :
                    course.Assignments  = new List<Assignment>
                    {
                        new Assignment() { Name = "Assignment 1", Mark = 0, Weight = 10 },
                        new Assignment() { Name = "Assignment 2", Mark = 0, Weight = 10 },
                        new Assignment() { Name = "Assignment 3", Mark = 0, Weight = 10 }
                    };
                    course.Name = "SFWRENG 3BB4";
                    course.Final = new Final() { Name = "Final Exam", Mark = 0, Weight = 50 };
                    course.Midterms = new List<Midterm>
                    {
                        new Midterm() { Name = "Midterm 1", Mark = 0, Weight = 20 }
                    };
                    return View("Course", course);
                
                case "3RA3" :
                    course.Assignments  = new List<Assignment>
                    {
                        new Assignment() { Name = "ACME Project", Mark = 0, Weight = 40 },
                    };
                    course.Name = "SFWRENG 3RA3";
                    course.Final = new Final() { Name = "Final Exam", Mark = 0, Weight = 45 };
                    course.Midterms = new List<Midterm>
                    {
                        new Midterm() { Name = "Midterm 1", Mark = 0, Weight = 15 }
                    };
                    return View("Course", course);
                
                default:
                    return RedirectToAction("Index", "Home");
                    
            }
     
        }
    }
}