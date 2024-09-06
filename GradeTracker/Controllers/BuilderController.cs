using Microsoft.AspNetCore.Mvc;
using GradeTracker.Models;

namespace GradeTracker.Controllers
{
    public class BuilderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public IActionResult SaveGradeToCookie([FromBody] GradeInputModel gradeInput)
        {
            try
            {
                if (string.IsNullOrEmpty(gradeInput.CourseName) || string.IsNullOrEmpty(gradeInput.GradeName) || gradeInput.GradeValue < 0 || gradeInput.GradeValue > 100)
                {
                    return BadRequest(new { success = false, message = "Invalid input" });
                }

                // Sanitize the cookie name by replacing spaces with underscores
                string cookieKey = $"{gradeInput.CourseName}_{gradeInput.GradeName}".Replace(" ", "_");

                // Save the grade to the cookie
                CookieOptions options = new CookieOptions
                {
                    Expires = DateTime.Now.AddYears(1),  // Set cookie to expire in 1 year
                    HttpOnly = true,  // Prevent access via JavaScript for security
                    Secure = true     // Only send cookie over HTTPS
                };

                HttpContext.Response.Cookies.Append(cookieKey, gradeInput.GradeValue.ToString(), options);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                // Catch any unexpected errors and return them as a JSON response
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }


        private double GetGradeFromCookie(string courseName, string gradeName)
        {
            // Sanitize the cookie name to match the stored format
            string cookieKey = $"{courseName}_{gradeName}".Replace(" ", "_");

            var cookieValue = HttpContext.Request.Cookies[cookieKey];
            if (double.TryParse(cookieValue, out double gradeValue))
            {
                return gradeValue;
            }
            return 0; // Default if no cookie found
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
                        new Assignment() { Name = "Assignment 1", Mark = GetGradeFromCookie(course.Name, "Assignment 1"), Weight = 12 },
                        new Assignment() { Name = "Assignment 2", Mark = GetGradeFromCookie(course.Name, "Assignment 2"), Weight = 14 },
                        new Assignment() { Name = "Assignment 3", Mark = GetGradeFromCookie(course.Name, "Assignment 3"), Weight = 14 }
                    };
                    course.Final = new Final() { Name = "Final Exam", Mark = GetGradeFromCookie(course.Name, "Final Exam"), Weight = 40 };
                    course.Midterms = new List<Midterm>
                    {
                        new Midterm() { Name = "Midterm 1", Mark = GetGradeFromCookie(course.Name, "Midterm 1"), Weight = 20 }
                    };
                    break;

                case "3O03":
                    course.Name = "SFWRENG 3O03";
                    course.Assignments = new List<Assignment>
                    {
                        new Assignment() { Name = "Assignment 1", Mark = GetGradeFromCookie(course.Name, "Assignment 1"), Weight = 10 },
                        new Assignment() { Name = "Assignment 2", Mark = GetGradeFromCookie(course.Name, "Assignment 2"), Weight = 10 },
                        new Assignment() { Name = "Assignment 3", Mark = GetGradeFromCookie(course.Name, "Assignment 3"), Weight = 10 }
                    };
                    course.Final = new Final() { Name = "Final Exam", Mark = GetGradeFromCookie(course.Name, "Final Exam"), Weight = 40 };
                    course.Midterms = new List<Midterm>
                    {
                        new Midterm() { Name = "Midterm 1", Mark = GetGradeFromCookie(course.Name, "Midterm 1"), Weight = 30 }
                    };
                    break;

                case "3MX3":
                    course.Assignments = new List<Assignment>();
                    course.Name = "SFWRENG 3MX3";
                    course.Final = new Final() { Name = "Final Exam", Mark = GetGradeFromCookie(course.Name, "Final Exam"), Weight = 60 };
                    course.Midterms = new List<Midterm>
                    {
                        new Midterm() { Name = "Midterm 1", Mark = GetGradeFromCookie(course.Name, "Midterm 1"), Weight = 20 },
                        new Midterm() { Name = "Midterm 2", Mark = GetGradeFromCookie(course.Name, "Midterm 2"), Weight = 20 }
                    };
                    break;

                case "3BB4":
                    course.Name = "SFWRENG 3BB4";
                    course.Assignments = new List<Assignment>
                    {
                        new Assignment() { Name = "Assignment 1", Mark = GetGradeFromCookie(course.Name, "Assignment 1"), Weight = 10 },
                        new Assignment() { Name = "Assignment 2", Mark = GetGradeFromCookie(course.Name, "Assignment 2"), Weight = 10 },
                        new Assignment() { Name = "Assignment 3", Mark = GetGradeFromCookie(course.Name, "Assignment 3"), Weight = 10 }
                    };
                    course.Final = new Final() { Name = "Final Exam", Mark = GetGradeFromCookie(course.Name, "Final Exam"), Weight = 50 };
                    course.Midterms = new List<Midterm>
                    {
                        new Midterm() { Name = "Midterm 1", Mark = GetGradeFromCookie(course.Name, "Midterm 1"), Weight = 20 }
                    };
                    break;

                case "3RA3":
                    course.Name = "SFWRENG 3RA3";
                    course.Assignments = new List<Assignment>
                    {
                        new Assignment() { Name = "ACME Project", Mark = GetGradeFromCookie(course.Name, "ACME Project"), Weight = 40 }
                    };
                    course.Final = new Final() { Name = "Final Exam", Mark = GetGradeFromCookie(course.Name, "Final Exam"), Weight = 45 };
                    course.Midterms = new List<Midterm>
                    {
                        new Midterm() { Name = "Midterm 1", Mark = GetGradeFromCookie(course.Name, "Midterm 1"), Weight = 15 }
                    };
                    break;

                default:
                    return RedirectToAction("Index", "Home");
            }

            return View("Course", course);
        }
    }
}
