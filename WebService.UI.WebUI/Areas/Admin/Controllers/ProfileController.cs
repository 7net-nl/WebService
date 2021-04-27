using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.UI.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace WebService.UI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfileController : Controller
    {
        private readonly UserManager<MyUsers> user;
        private readonly SignInManager<MyUsers> signIn;

        public ProfileController(UserManager<MyUsers> user,SignInManager<MyUsers> signIn)
        {
            this.user = user;
            this.signIn = signIn;
        }

        [HttpGet]
        public async Task<IActionResult> Login(string ReturnUrl="") => View(new LoginViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                var Users = await user.FindByEmailAsync(model.UserName);
                if (Users != null)
                {
                    var Result = await signIn.PasswordSignInAsync(Users, model.Password, false, false);

                    if (Result.Succeeded)
                    {
                        return string.IsNullOrEmpty(model.ReturnUrl)  ? LocalRedirect("/Admin/Home/Index") : LocalRedirect(model.ReturnUrl) ;
                    }
                    else
                    {
                        ModelState.AddModelError("Error", "UserName And Password Not Match");
                    }
                }

                else
                {
                    ModelState.AddModelError("Error", "UserName And Password Not Found");
                }

            }
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await signIn.SignOutAsync();
            return RedirectToAction("Login", "Profile");
        }

        public IActionResult Error()
        {
          return  RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
