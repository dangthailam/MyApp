using IdentityServer.Context;
using IdentityServer3.AspNetIdentity;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer.UserService
{
    public static class UserServiceExtensions
    {
        public static void ConfigureCustomUserService(this IdentityServerServiceFactory factory)
        {
            factory.UserService = new Registration<IUserService, UserService>();
            factory.Register(new Registration<CustomUserManager>());
            factory.Register(new Registration<CustomUserStore>());
            factory.Register(new Registration<ApplicationDbContext>(resolver => new ApplicationDbContext()));
        }
    }

    public class UserService : AspNetIdentityUserService<CustomUser, int>
    {
        public UserService(CustomUserManager userMgr) : base(userMgr)
        {
        }
    }
}
