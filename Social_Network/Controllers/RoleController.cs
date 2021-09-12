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

    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        UserManager<UserProfilesDTO> userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<UserProfilesDTO> userManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if(!String.IsNullOrEmpty(roleName))
            {
                IdentityResult rez = await roleManager.CreateAsync(new IdentityRole(roleName));
                if(rez.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    string ex = "";
                    foreach (var error in rez.Errors)
                    {
                        ex += error.Description;
                    }
                    this.ModelState.AddModelError("roleName", ex);
                }
            }
            return View(roleName);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult AllRoles()
        {
            var list_rol = roleManager.Roles.ToList();
            return View(list_rol);
        }

        [HttpGet]
        [Authorize]
        public IActionResult AllUsers()
        {
            var list_user = userManager.Users.ToList();
            return View(list_user);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddRoleToUser(string id)
        {
            var u = await userManager.FindByIdAsync(id);
            if(u != null)
            {
                var user_roles = await userManager.GetRolesAsync(u);
                var all_roles = roleManager.Roles.ToList();
                ViewData["AllRoles"] = all_roles;
                var u_r = new RoleViewModel() {
                    UserId = u.Id,
                    UserEmail = u.Email,
                    UserRoles = user_roles
                };

                return View(u_r);
            }
            return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddRoleToUser(string Id, string role)
        {
            var u = await userManager.FindByIdAsync(Id);
            if(u !=null)
            {
                var user_roles = await userManager.GetRolesAsync(u);
                user_roles.Add(role);
                await userManager.AddToRoleAsync(u, role);

                return RedirectToAction("AllUsers");
            }
            return NotFound();
        }

    }
}
