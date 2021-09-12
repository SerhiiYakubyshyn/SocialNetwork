using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using BuisnesLogicLayer.DTOModels;
using Social_Network.Models;

namespace Social_Network.Controllers
{
    public class ProfileController : Controller
    {

        public readonly UserManager<UserProfilesDTO> userManager;
        public ProfileController(UserManager<UserProfilesDTO> userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ShowProfile()
        {

            UserProfilesDTO user = await userManager.GetUserAsync(User);

             var user_role = await userManager.GetRolesAsync(user);
             ViewData["Roles"] = user_role;

            var rez = new UserProfileView { Country = user.Country, Email = user.Email, UserName = user.UserName};

           return View(rez);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditProfile()
        {
            UserProfilesDTO user = await userManager.GetUserAsync(User);
            var rez = new UserProfileView { Country = user.Country, Email = user.Email, UserName = user.UserName};

            return View(rez);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditProfile(UserProfileView profile)
        {
            if(ModelState.IsValid)
            {
                UserProfilesDTO user = await userManager.GetUserAsync(User);
                if(user != null)
                {
                    user.Email = profile.Email;
                    user.Country = profile.Country;
                    user.UserName = profile.UserName;
                    await userManager.UpdateAsync(user);
                    return RedirectToAction("ShowProfile", "Profile");
                }
                return NotFound();
            }

            return View(profile);

        }

    }
}
