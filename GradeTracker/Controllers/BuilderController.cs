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
    [HttpPost]
    public IActionResult SaveGrade([FromBody] GradeInputModel gradeInput)
    {
        if (string.IsNullOrEmpty(gradeInput.CourseName) || string.IsNullOrEmpty(gradeInput.GradeName) || gradeInput.GradeValue < 0 || gradeInput.GradeValue > 100)
        {
            return BadRequest(new { success = false, message = "Invalid input" });
        }

        // Save the grade to the session
        string key = $"{gradeInput.CourseName}_{gradeInput.GradeName}";
        HttpContext.Session.SetString(key, gradeInput.GradeValue.ToString());

        // Log all session keys and values to debug
        Console.WriteLine("####");
        foreach (var sessionKey in HttpContext.Session.Keys)
        {
            var sessionValue = HttpContext.Session.GetString(sessionKey);
            Console.WriteLine($"Session key: {sessionKey}, value: {sessionValue}");
        }

        return Json(new { success = true });
    }



    public IActionResult GetGrade(string key)
    {
        var value = HttpContext.Session.GetString(key);
        return Json(value);
    }
    public IActionResult Build(string courseName)
    {
        Course course = new Course();
        switch (courseName)
        {
            case "3DB3":
                course.Name = "SFWRENG 3DB3";
                course.Assignments = new List<Assignment>
                {
                    new Assignment() { Name = "Assignment 1", Mark = GetGradeFromSession($"{course.Name}_Assignment 1"), Weight = 12 },
                    new Assignment() { Name = "Assignment 2", Mark = GetGradeFromSession($"{course.Name}_Assignment 2"), Weight = 14 },
                    new Assignment() { Name = "Assignment 3", Mark = GetGradeFromSession($"{course.Name}_Assignment 3"), Weight = 14 }
                };
                course.Final = new Final() { Name = "Final Exam", Mark = GetGradeFromSession($"{course.Name}_Final Exam"), Weight = 40 };
                course.Midterms = new List<Midterm>
                {
                    new Midterm() { Name = "Midterm 1", Mark = GetGradeFromSession($"{course.Name}_Midterm 1"), Weight = 20 }
                };
                break;

            case "3O03":
                course.Name = "SFWRENG 3O03";
                course.Assignments = new List<Assignment>
                {
                    new Assignment() { Name = "Assignment 1", Mark = GetGradeFromSession($"{course.Name}_Assignment 1"), Weight = 10 },
                    new Assignment() { Name = "Assignment 2", Mark = GetGradeFromSession($"{course.Name}_Assignment 2"), Weight = 10 },
                    new Assignment() { Name = "Assignment 3", Mark = GetGradeFromSession($"{course.Name}_Assignment 3"), Weight = 10 }
                };
                course.Final = new Final() { Name = "Final Exam", Mark = GetGradeFromSession($"{course.Name}_Final Exam"), Weight = 40 };
                course.Midterms = new List<Midterm>
                {
                    new Midterm() { Name = "Midterm 1", Mark = GetGradeFromSession($"{course.Name}_Midterm 1"), Weight = 30 }
                };
                break;

            case "3MX3":
                course.Assignments = new List<Assignment>();
                course.Name = "SFWRENG 3MX3";
                course.Final = new Final() { Name = "Final Exam", Mark = GetGradeFromSession($"{course.Name}_Final Exam"), Weight = 60 };
                course.Midterms = new List<Midterm>
                {
                    new Midterm() { Name = "Midterm 1", Mark = GetGradeFromSession($"{course.Name}_Midterm 1"), Weight = 20 },
                    new Midterm() { Name = "Midterm 2", Mark = GetGradeFromSession($"{course.Name}_Midterm 2"), Weight = 20 }
                };
                break;

            case "3BB4":
                course.Assignments = new List<Assignment>
                {
                    new Assignment() { Name = "Assignment 1", Mark = GetGradeFromSession($"{course.Name}_Assignment 1"), Weight = 10 },
                    new Assignment() { Name = "Assignment 2", Mark = GetGradeFromSession($"{course.Name}_Assignment 2"), Weight = 10 },
                    new Assignment() { Name = "Assignment 3", Mark = GetGradeFromSession($"{course.Name}_Assignment 3"), Weight = 10 }
                };
                course.Name = "SFWRENG 3BB4";
                course.Final = new Final() { Name = "Final Exam", Mark = GetGradeFromSession($"{course.Name}_Final Exam"), Weight = 50 };
                course.Midterms = new List<Midterm>
                {
                    new Midterm() { Name = "Midterm 1", Mark = GetGradeFromSession($"{course.Name}_Midterm 1"), Weight = 20 }
                };
                break;

            case "3RA3":
                course.Assignments = new List<Assignment>
                {
                    new Assignment() { Name = "ACME Project", Mark = GetGradeFromSession($"{course.Name}_ACME Project"), Weight = 40 }
                };
                course.Name = "SFWRENG 3RA3";
                course.Final = new Final() { Name = "Final Exam", Mark = GetGradeFromSession($"{course.Name}_Final Exam"), Weight = 45 };
                course.Midterms = new List<Midterm>
                {
                    new Midterm() { Name = "Midterm 1", Mark = GetGradeFromSession($"{course.Name}_Midterm 1"), Weight = 15 }
                };
                break;

            default:
                return RedirectToAction("Index", "Home");
        }
        Console.WriteLine("####");
        foreach (var sessionKey in HttpContext.Session.Keys)
        {
            var sessionValue = HttpContext.Session.GetString(sessionKey);
            Console.WriteLine($"Session key: {sessionKey}, value: {sessionValue}");
        }
        return View("Course", course);
    }

    private double GetGradeFromSession(string key)
    {
        var value = HttpContext.Session.GetString(key);
        return double.TryParse(value, out var result) ? result : 0;
    }
    }
}