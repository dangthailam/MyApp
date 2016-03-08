using IdentityManager;
using IdentityManager.AspNetIdentity;
using IdentityManager.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.Context
{
    public class CustomIdentityManagerService : AspNetIdentityManagerService<CustomUser, int, CustomRole, int>
    {
        public CustomIdentityManagerService(CustomUserManager userMgr, CustomRoleManager roleMgr)
            : base(userMgr, roleMgr)
        {
        }
    }

    public static class CustomIdentityManagerServiceExtensions
    {
        public static void ConfigureCustomIdentityManagerService(this IdentityManagerServiceFactory factory, string connectionString)
        {
            factory.Register(new Registration<ApplicationDbContext>(resolver => new ApplicationDbContext(connectionString)));
            factory.Register(new Registration<CustomUserStore>());
            factory.Register(new Registration<CustomRoleStore>());
            factory.Register(new Registration<CustomUserManager>());
            factory.Register(new Registration<CustomRoleManager>());
            factory.IdentityManagerService = new Registration<IIdentityManagerService, CustomIdentityManagerService>();
        }
    }
}
