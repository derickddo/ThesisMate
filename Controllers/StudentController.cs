using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThesisMate.DTOs;
using ThesisMate.Enums;
using ThesisMate.Models;
using ThesisMate.Repositories;

namespace ThesisMate.Controllers {

    public class StudentController(IUserRepository _userRepository, IFileRepository _fileRepository) : Controller {

        public IActionResult Index() {
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
            if (role.RoleType != "Student") {
                return RedirectToAction("Forbidden", "Home");
            }


            var student = _userRepository.GetStudentById(userObj.UserId);
            var supervisor = _userRepository.GetStudentSupervisor(userObj.UserId);
            StudentWithSupervisor studentWithSupervisor;

            if (supervisor != null){
                    studentWithSupervisor = new StudentWithSupervisor(
                    student.UserId,
                    student.FirstName + " " + student.LastName,
                    student.Email,
                    supervisor.UserId,
                    supervisor.FirstName + " " + supervisor.LastName,
                    HasSupervisor: true
                );
            }
            else{
                    studentWithSupervisor = new StudentWithSupervisor(
                    student.UserId,
                    student.FirstName + " " + student.LastName,
                    student.Email,
                    0,
                    "",
                    HasSupervisor: false
                );
            }

            var proposals = _userRepository.GetStudentProposals(userObj.UserId);    
            

            ViewBag.StudentWithSupervisor = studentWithSupervisor;
            ViewBag.Proposals = proposals;
            return View();
        }

        [HttpPost]
        public IActionResult UploadProposal() {
            var user = HttpContext.Session.GetString("user");
            if (user == null) {
                return RedirectToAction("Login", "Account");
            }

            var userObj = JsonConvert.DeserializeObject<User>(user);
            if (userObj == null) {
                return RedirectToAction("Login", "Account");
            }
            var formData = Request.Form;
            var file = formData.Files["proposalFile"];
            var path = _fileRepository.UploadFile(file!);

            var proposal = new Proposal {
                ProposalName = formData["proposalName"]!,
                ProposalFile = path,
                UserId = userObj.UserId,
                StatusId = (int)ProposalStatusEnum.Pending
            };
            _userRepository.UploadProposal(proposal);
            return RedirectToAction("Index");
        }
    }
}