using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using BuisnesLogicLayer.DTOModels;
using Social_Network.Models;

namespace Social_Network.Controllers
{
    public class AccountController : Controller
    {
        public readonly UserManager<UserProfilesDTO> userManager;
        public readonly SignInManager<UserProfilesDTO> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AccountController(UserManager<UserProfilesDTO> userManager, SignInManager<UserProfilesDTO> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
   
        public async Task<IActionResult> Register(Registration registration)
        {
            var rez_rol = await roleManager.FindByNameAsync("user");
            if(ModelState.IsValid)
            {
                UserProfilesDTO user = new UserProfilesDTO { Email = registration.Email, UserName = registration.Email ,Country = registration.Country };
              
                IdentityResult rez = await userManager.CreateAsync(user, registration.Password);
                if(rez.Succeeded)
                {
                    if (rez_rol != null)
                    {
                        string namerol = rez_rol.Name;
                        var rez_roll_add = await userManager.AddToRoleAsync(user, namerol);

                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    string ex = "";
                    foreach(var error in rez.Errors)
                    {
                        ex += error.Description;
                    }
                    this.ModelState.AddModelError("Password", ex);
                }
            }

            return View(registration);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if(ModelState.IsValid)
            {
                var rez = await signInManager.PasswordSignInAsync(login.Email, login.Password, false , false);
                if(rez.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return NotFound();
                }
            }

            return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
