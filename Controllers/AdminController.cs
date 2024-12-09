using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThesisMate.DTOs;
using ThesisMate.Models;
using ThesisMate.Repositories;


namespace ThesisMate.Controllers{
    public class AdminController(IUserRepository _userRepository) : Controller
    {
        

        public IActionResult Index()
        {   
            // get user from session
            var user = HttpContext.Session.GetString("user");
            Console.WriteLine(user);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var userObj = JsonConvert.DeserializeObject<User>(user);
            if (userObj == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var role = _userRepository.GetUserRole(userObj.RoleId);
            if (role.RoleType != "Admin")
            {
                
                // show forbidden page
                return View("Forbidden");
            }
            // get all students and supervisors
            var students = _userRepository.GetStudents();
            var supervisors = _userRepository.GetSupervisors();
            var studentWithSupervisors = new List<StudentWithSupervisor>();
            
            foreach (var student in students)
            {
                // query supervisor for each student
                var supervisor = _userRepository.GetStudentSupervisor(student.UserId);

                if (supervisor != null)
                {
                    studentWithSupervisors.Add(
                        new StudentWithSupervisor(
                            student.UserId,
                            student.FirstName + " " + student.LastName,
                            student.Email,
                            supervisor.UserId,
                            supervisor.FirstName + " " + supervisor.LastName,
                            HasSupervisor: true
                        )
                    );
                }
                else
                {
                    studentWithSupervisors.Add(
                        new StudentWithSupervisor(
                            student.UserId,
                            student.FirstName + " " + student.LastName,
                            student.Email,
                            0,
                            "",
                            HasSupervisor: false
                        )
                    );
                }

              
            }
            ViewBag.Students = studentWithSupervisors;
            ViewBag.Supervisors = supervisors;
            
            return View(); 
        }

        // assign supervisor to student
        [HttpPost]
        public IActionResult AssignSupervisor()
        {
            // get user from session
            var user = HttpContext.Session.GetString("user");
            Console.WriteLine(user);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var userObj = JsonConvert.DeserializeObject<User>(user);
            if (userObj == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var role = _userRepository.GetUserRole(userObj.RoleId);
            if (role.RoleType != "Admin")
            {
                
                // show forbidden page
                return View("Forbidden");
            }
            var formData = HttpContext.Request.Form;
            var supervisorId = int.Parse(formData["supervisor"]!);
            var studentId = int.Parse(formData["studentId"]!);

            // assign supervisor to student
            _userRepository.AssignSupervisor(supervisorId, studentId);

            Console.WriteLine(supervisorId);
            Console.WriteLine(studentId);

            return RedirectToAction("Index");
        }

        
    }

}