using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class VmRoleModel
    {
        public List<IdentityRole> liRoles { set; get; }

        public RoleModel roleModel { set; get; }
    }
}
