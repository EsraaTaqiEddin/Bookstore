using Bookstore.Models;
using Bookstore.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    public class AccountController : Controller
    {
        IAccountService accountServices;
        public AccountController(IAccountService _accountServices)
        {
            accountServices = _accountServices;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            SignUpViewModel vm = new SignUpViewModel();
            List<IdentityRole> liRole = accountServices.GetRoles();
            vm.liRoles = liRole;
            return View("CreateAccount", vm);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAccount(SignUpViewModel signUpViewModel)
        {
            SignUpViewModel vm = new SignUpViewModel();
            List<IdentityRole> liRole = accountServices.GetRoles();
            vm.liRoles = liRole;
            var result = await accountServices.CreateUser(signUpViewModel.signUpModel);

            return View("CreateAccount", vm);
        }
        public IActionResult SignIn()
        {
            return View("Login");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SignOut()
        {
            await accountServices.Logout();
            return View("Login");
        }
        public async Task<IActionResult> Checkpassword(SignInModel signInModel)
        {
            var result = await accountServices.Checkpassword(signInModel);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Book");
            }
            else
            {
                ViewData["errorMessage"] = "Invalid Username or Password";
                return View("Login");
            }
        }
        [Authorize(Roles ="Admin")]
        public IActionResult NewRole()
        {
            VmRoleModel vm = new VmRoleModel();
            List<IdentityRole> liRole = accountServices.GetRoles();
            vm.liRoles = liRole;
            return View("NewRole", vm);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SaveRole(RoleModel roleModel)
        {
            VmRoleModel vm = new VmRoleModel();
            List<IdentityRole> liRole = accountServices.GetRoles();
            vm.liRoles = liRole;
            var result = await accountServices.NewRole(roleModel);
            return View("NewRole", vm);
        }
        public IActionResult AccessDenied()
        {
            return View("");
        }
    }
}