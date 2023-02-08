using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OlmosBartending.com.Models;
using OlmosBartending.com.ViewModels;

namespace OlmosBartending.com.Controllers
{
    public class UserController : Controller
    {
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;
        public UserController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public IActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure:false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Failed to login");
            return View();
        }
        //GET
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if(ModelState.IsValid)
            {
                User newUser = new User();
                newUser.FirstName= registerViewModel.FirstName;
                newUser.LastName= registerViewModel.LastName;
                newUser.Email= registerViewModel.Email;
                newUser.UserName= registerViewModel.UserName;
                var result = await userManager.CreateAsync(newUser, registerViewModel.Password);
                if (result.Succeeded)
                {
                    if (newUser.UserName == "rolando")
                    {
                        await userManager.AddToRoleAsync(newUser, "admin");
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(newUser, "client");
                    }
                    return RedirectToAction("Index", "Home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(registerViewModel);
        }
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        //GET
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return RedirectToPage("/Denied");
        }
    }
}
