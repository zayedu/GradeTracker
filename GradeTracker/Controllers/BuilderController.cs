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
                        new Assignment() { Name = "Assignment 1", Mark = GetGradeFromCookie(course.Name, "Assignment 1"), Weight = 12,DueDate = DateTime.Parse("2024-09-27 23:59:00") },
                        new Assignment() { Name = "Assignment 2", Mark = GetGradeFromCookie(course.Name, "Assignment 2"), Weight = 14 },
                        new Assignment() { Name = "Assignment 3", Mark = GetGradeFromCookie(course.Name, "Assignment 3"), Weight = 14 }
                    };
                    course.Final = new Final() { Name = "Final Exam", Mark = GetGradeFromCookie(course.Name, "Final Exam"), Weight = 40 };
                    course.Midterms = new List<Midterm>
                    {
                        new Midterm() { Name = "Midterm 1", Mark = GetGradeFromCookie(course.Name, "Midterm 1"), Weight = 20, DueDate = DateTime.Parse("2024-10-24 10:30:00") }
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
                        new Midterm() { Name = "Midterm 1", Mark = GetGradeFromCookie(course.Name, "Midterm 1"), Weight = 20 , DueDate = DateTime.Parse("2024-10-10 15:30:00")},
                        new Midterm() { Name = "Midterm 2", Mark = GetGradeFromCookie(course.Name, "Midterm 2"), Weight = 20 , DueDate = DateTime.Parse("2024-11-12 16:30:00")}
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
                        new Assignment() { Name = "ACME Project", Mark = GetGradeFromCookie(course.Name, "ACME Project"), Weight = 40, DueDate = DateTime.Parse("2024-12-05 23:59:00") }
                    };
                    course.Final = new Final() { Name = "Final Exam", Mark = GetGradeFromCookie(course.Name, "Final Exam"), Weight = 45 , DueDate = DateTime.Parse("2024-10-22 15:30:00")};
                    course.Midterms = new List<Midterm>
                    {
                        new Midterm() { Name = "Midterm 1", Mark = GetGradeFromCookie(course.Name, "Midterm 1"), Weight = 15 }
                    };
                    break; 
                case "3SH3":
                    course.Name = "SFWRENG 3SH3";
                    course.Assignments = new List<Assignment>
                    {
                        new Assignment() { Name = "Assignment 1", Mark = GetGradeFromCookie(course.Name, "Assignment 1"), Weight = 6 },
                        new Assignment() { Name = "Assignment 2", Mark = GetGradeFromCookie(course.Name, "Assignment 2"), Weight = 6 },
                        new Assignment() { Name = "Assignment 3", Mark = GetGradeFromCookie(course.Name, "Assignment 3"), Weight = 6 },
                        new Assignment() { Name = "Assignment 4", Mark = GetGradeFromCookie(course.Name, "Assignment 4"), Weight = 6 },
                        new Assignment() { Name = "Lab 1", Mark = GetGradeFromCookie(course.Name, "Lab 1"), Weight = 2 },
                        new Assignment() { Name = "Lab 2", Mark = GetGradeFromCookie(course.Name, "Lab 2"), Weight = 2 },
                        new Assignment() { Name = "Lab 3", Mark = GetGradeFromCookie(course.Name, "Lab 3"), Weight = 2 },
                        
                    };
                    course.Final = new Final() { Name = "Final Exam", Mark = GetGradeFromCookie(course.Name, "Final Exam"), Weight = 40 };
                    course.Midterms = new List<Midterm>
                    {
                        new Midterm() { Name = "Midterm", Mark = GetGradeFromCookie(course.Name, "Midterm"), Weight = 30 }
                    };
                    break;

                case "3DX4":
                    course.Name = "SFWRENG 3DX4";
                    course.Assignments = new List<Assignment>
                        {
                            new Assignment() { Name = "Lab 1", Mark = GetGradeFromCookie(course.Name, "Lab 1"), Weight = 6 },
                            new Assignment() { Name = "Lab 2", Mark = GetGradeFromCookie(course.Name, "Lab 2"), Weight = 6 },
                            new Assignment() { Name = "Lab 3", Mark = GetGradeFromCookie(course.Name, "Lab 3"), Weight = 6 },
                            new Assignment() { Name = "Lab 4", Mark = GetGradeFromCookie(course.Name, "Lab 4"), Weight = 6 },
                            new Assignment() { Name = "Lab 5", Mark = GetGradeFromCookie(course.Name, "Lab 5"), Weight = 6 },
                            new Assignment() { Name = "Quiz 1", Mark = GetGradeFromCookie(course.Name, "Quiz 1"), Weight = 1.25 },
                            new Assignment() { Name = "Quiz 2", Mark = GetGradeFromCookie(course.Name, "Quiz 2"), Weight = 1.25 },
                            new Assignment() { Name = "Quiz 3", Mark = GetGradeFromCookie(course.Name, "Quiz 3"), Weight = 1.25},
                            new Assignment() { Name = "Quiz 4", Mark = GetGradeFromCookie(course.Name, "Quiz 4"), Weight = 1.25 },
                            new Assignment() { Name = "Quiz 5", Mark = GetGradeFromCookie(course.Name, "Quiz 5"), Weight = 1.25 },
                            new Assignment() { Name = "Quiz 6", Mark = GetGradeFromCookie(course.Name, "Quiz 6"), Weight = 1.25 },
                            new Assignment() { Name = "Quiz 7", Mark = GetGradeFromCookie(course.Name, "Quiz 7"), Weight = 1.25 },
                            new Assignment() { Name = "Quiz 8", Mark = GetGradeFromCookie(course.Name, "Quiz 8"), Weight = 1.25 }
                        };
                    
                    course.Final = new Final() { Name = "Final Exam", Mark = GetGradeFromCookie(course.Name, "Final Exam"), Weight = 35 };
                    course.Midterms = new List<Midterm>
                    {
                        new Midterm() { Name = "Midterm", Mark = GetGradeFromCookie(course.Name, "Midterm"), Weight = 25 }
                    };
                    break;

                case "3A04":
                    course.Name = "SFWRENG 3A04";
                    course.Assignments = new List<Assignment>
                    {
                        new Assignment() { Name = "Deliverable 1", Mark = GetGradeFromCookie(course.Name, "Deliverable 1"), Weight = 10 },
                        new Assignment() { Name = "Deliverable 2", Mark = GetGradeFromCookie(course.Name, "Deliverable 2"), Weight = 10 },
                        new Assignment() { Name = "Deliverable 3", Mark = GetGradeFromCookie(course.Name, "Deliverable 3"), Weight = 10 },
                        new Assignment() { Name = "Deliverable 4", Mark = GetGradeFromCookie(course.Name, "Deliverable 4"), Weight = 10 }


                    };
                    course.Final = new Final() { Name = "Final Exam", Mark = GetGradeFromCookie(course.Name, "Final Exam"), Weight = 40 };
                    course.Midterms = new List<Midterm>
                    {
                        new Midterm() { Name = "Midterm", Mark = GetGradeFromCookie(course.Name, "Midterm"), Weight = 20 }
                    };
                    break;

                case "3PX3":
                    course.Name = "ENGINEER 3PX3";
                    course.Assignments = new List<Assignment>
                        {
                            new Assignment() { Name = "Quiz 1", Mark = GetGradeFromCookie(course.Name, "Quiz 1"), Weight = 1 },
                            new Assignment() { Name = "Quiz 2", Mark = GetGradeFromCookie(course.Name, "Quiz 2"), Weight = 1 },
                            new Assignment() { Name = "Quiz 3", Mark = GetGradeFromCookie(course.Name, "Quiz 3"), Weight = 1 },
                            new Assignment() { Name = "Quiz 4", Mark = GetGradeFromCookie(course.Name, "Quiz 4"), Weight = 1 },
                            new Assignment() { Name = "Quiz 5", Mark = GetGradeFromCookie(course.Name, "Quiz 5"), Weight = 1 },
                            new Assignment() { Name = "Quiz 6", Mark = GetGradeFromCookie(course.Name, "Quiz 6"), Weight = 1 },
                            new Assignment() { Name = "Quiz 7", Mark = GetGradeFromCookie(course.Name, "Quiz 7"), Weight = 1 },
                            new Assignment() { Name = "Quiz 8", Mark = GetGradeFromCookie(course.Name, "Quiz 8"), Weight = 1 },
                            new Assignment() { Name = "Individual Introductory Project Report", Mark = GetGradeFromCookie(course.Name, "Individual Introductory Project Report"), Weight = 7 },
                            new Assignment() { Name = "Main Progress Check-In", Mark = GetGradeFromCookie(course.Name, "Main Progress Check-In"), Weight = 8 },
                            new Assignment() { Name = "Simple Report", Mark = GetGradeFromCookie(course.Name, "Simple Report"), Weight = 9 },
                            new Assignment() { Name = "Simple Report Interview", Mark = GetGradeFromCookie(course.Name, "Simple Report Interview"), Weight = 4 },
                            new Assignment() { Name = "Complex Report", Mark = GetGradeFromCookie(course.Name, "Complex Report"), Weight = 18 },
                            new Assignment() { Name = "Complex Report Interview", Mark = GetGradeFromCookie(course.Name, "Complex Report Interview"), Weight = 8 },
                            new Assignment() { Name = "Main Project Self Reflection", Mark = GetGradeFromCookie(course.Name, "Main Project Self Reflection"), Weight = 3 }
                        };
                    course.Final = new Final() { Name = "Final Exam", Mark = GetGradeFromCookie(course.Name, "Final Exam"), Weight = 35 };
                    break;

                case "3S03":
                    course.Name = "SFWRENG 3S03";
                    course.Assignments = new List<Assignment>
                    {
                        new Assignment() { Name = "Assignment 1", Mark = GetGradeFromCookie(course.Name, "Assignment 1"), Weight = 10 },
                        new Assignment() { Name = "Assignment 2", Mark = GetGradeFromCookie(course.Name, "Assignment 2"), Weight = 10 },
                        new Assignment() { Name = "Assignment 3", Mark = GetGradeFromCookie(course.Name, "Assignment 3"), Weight = 10 }
                    };
                    course.Final = new Final() { Name = "Final Exam", Mark = GetGradeFromCookie(course.Name, "Final Exam"), Weight = 50 };
                    course.Midterms = new List<Midterm>
                    {
                        new Midterm() { Name = "Midterm", Mark = GetGradeFromCookie(course.Name, "Midterm"), Weight = 20 }
                    };
                    break;

                default:
                    return RedirectToAction("Index", "Home");
            }

            return View("Course", course);
        }
    }
}
