using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Context
{
    public class CustomUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim> { }
    public class CustomUserLogin : IdentityUserLogin<int> { }
    public class CustomUserRole : IdentityUserRole<int> { }
    public class CustomUserClaim : IdentityUserClaim<int> { }

    public class CustomRole : IdentityRole<int, CustomUserRole> { }

    public class ApplicationDbContext : IdentityDbContext<CustomUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public ApplicationDbContext(string connString)
            : base(connString)
        {
        }
    }

    public class CustomUserStore : UserStore<CustomUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(ApplicationDbContext ctx)
            : base(ctx)
        {
        }
    }

    public class CustomUserManager : UserManager<CustomUser, int>
    {
        public CustomUserManager(CustomUserStore store)
            : base(store)
        {
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(ApplicationDbContext ctx)
            : base(ctx)
        {
        }
    }

    public class CustomRoleManager : RoleManager<CustomRole, int>
    {
        public CustomRoleManager(CustomRoleStore store)
            : base(store)
        {
        }
    }
}
