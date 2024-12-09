using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThesisMate.DTOs;
using ThesisMate.Models;
using ThesisMate.Repositories;

namespace ThesisMate.Controllers {
    
    public class SupervisorController(IUserRepository _userRepository) : Controller {

        
        public IActionResult Index() {
            // get user from session
            var user = HttpContext.Session.GetString("user");
            Console.WriteLine(user);
            
            if (user == null) {
                return RedirectToAction("Login", "Account");
            }

            var userObj = JsonConvert.DeserializeObject<User>(user);
            if (userObj == null) {
                return RedirectToAction("Login", "Account");
            }
            var role = _userRepository.GetUserRole(userObj.RoleId);
            if (role.RoleType != "Supervisor") {
                
                // show forbidden page
                return View("Forbidden");
            }
            // get all students for a supervisor
            var students = _userRepository.GetSupervisorStudents(userObj.UserId);

            var studentWithProposals = new List<StudentWithProposals>();

            foreach (var student in students) {
                // query proposal for each student
                var proposals = _userRepository.GetStudentProposals(student.UserId);

                var studentProposal = new List<StudentProposal>(); // list of proposals

                if (proposals != null) {
                    foreach (var proposal in proposals) {
                        var status = _userRepository.GetProposalStatus(proposal.StatusId);

                        studentProposal.Add(
                            new StudentProposal(
                                proposal.ProposalId,
                                proposal.ProposalName,
                                proposal.ProposalFile,
                                status.Status
                            )
                        );
                    } 

                    studentWithProposals.Add(
                        new StudentWithProposals(
                            student.UserId,
                            student.FirstName + " " + student.LastName,
                            student.Email,
                            studentProposal // list of proposals
                        )
                    );  
                    
                }
                    
            }

            ViewBag.Students = students;
            ViewBag.StudentWithProposals = studentWithProposals;
            

            
            return View();
        }
    }
}