using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ThesisMate.DTOs;
using ThesisMate.Models;
using ThesisMate.Repositories;


namespace ThesisMate.Controllers {
    public class AccountController: Controller {

        private readonly IAuthenticationRepository _authRepository;
        private readonly IUserRepository _userRepository;

        public AccountController(IAuthenticationRepository authRepository, IUserRepository userRepository) {
            _authRepository = authRepository;
            _userRepository = userRepository;
        }

        public IActionResult Login() {
            // check if user is already logged in
            var user = HttpContext.Session.GetString("user");
            Console.WriteLine(user);

            if (user != null) {
                var userObj = JsonConvert.DeserializeObject<User>(user);
                if (userObj != null) {
                    var role = _userRepository.GetUserRole(userObj.RoleId);
                    if (role.RoleType == "Student") {
                        // set message
                        
                        return RedirectToAction("Index", "Student");
                    } else if (role.RoleType == "Supervisor") {
                        return RedirectToAction("Index", "Supervisor");
                    } else if (role.RoleType == "Admin") {
                        return RedirectToAction("Index", "Admin");
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO) {
            if (!ModelState.IsValid) {
                return View();
            }

            var email = loginDTO.Email;
            var password = loginDTO.Password;

            var (user, message) = _authRepository.Login(email!, password!);

            if (user == null) {
                ModelState.AddModelError("Email", message);
                return View(loginDTO);
            }

            // set user in session
            HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));

            
            var role = _userRepository.GetUserRole(user.RoleId);

            if (role.RoleType == "Student") {
                
                return RedirectToAction("Index", "Student");
                
            } else if (role.RoleType == "Supervisor") {
                
                return RedirectToAction("Index", "Supervisor");
            } else if (role.RoleType == "Admin") {
                return RedirectToAction("Index", "Admin");
            }

            return View(loginDTO);

        }

        public IActionResult Logout() {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Login");
        }
    }
}