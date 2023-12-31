﻿using Eduhome_again.Helpers;
using Eduhome_again.Models;
using Eduhome_again.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eduhome_again.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        #region Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            //firstordefault kimi isleyir null qayidacaq sehv islese 
            AppUser appUser = await _userManager.FindByNameAsync(loginVM.Username);//Name Usernamein name i dir yeni usernamedir

            if (appUser == null) //eger null olsa username email ile yoxla 
            {
                appUser = await _userManager.FindByEmailAsync(loginVM.Username); //email de null olsa sehv i qaytar
                if (appUser == null)
                {
                    ModelState.AddModelError("", "email ve username sehvdir");
                    return View();
                }
            }

            if (appUser.IsDeactive)
            {
                ModelState.AddModelError("", "Deaktive");
                return View();
            }

            //password sign in 
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, true, true);

            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "Limiti keçmisiniz");
                return View();
            }

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "İstifadəçi adı və şifrə səhvdir!");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            AppUser appUser = new AppUser
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                UserName = registerVM.Username,
                Email = registerVM.Email
            };

            IdentityResult identityResult = await _userManager.CreateAsync(appUser, password: registerVM.Password);

            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerVM);
            }


            await _userManager.AddToRoleAsync(appUser, Helper.Admin);
            await _signInManager.SignInAsync(appUser, true);

            return RedirectToAction("Index", "Home");
        }

        #region Create Roles
        public async Task CreateRoles()
        {
            if (!await _roleManager.RoleExistsAsync(Helper.Admin))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = Helper.Admin });
            }


            if (!await _roleManager.RoleExistsAsync(Helper.Member))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = Helper.Member });
            }

        }
        #endregion

        #region LogOut
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
