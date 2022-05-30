using Bookstore.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.services
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateUser(SignUpModel signUpModel);
        Task<SignInResult> Checkpassword(SignInModel signInModel);
        Task<IdentityResult> NewRole(RoleModel roleModel);
        List<IdentityRole> GetRoles();
        Task Logout();
    }
}
