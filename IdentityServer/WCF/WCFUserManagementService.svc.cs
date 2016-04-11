using IdentityServer.Context;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace IdentityServer.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCFUserManagementService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WCFUserManagementService.svc or WCFUserManagementService.svc.cs at the Solution Explorer and start debugging.
    public class WCFUserManagementService : IWCFUserManagementService
    {
        private CustomUserManager _customUserManager;

        public CustomUserManager CustomUserManager
        {
            get
            {
                if (_customUserManager == null)
                {
                    _customUserManager = new CustomUserManager();
                }
                return _customUserManager;
            }
        }

        public async Task Register(string userName, string password)
        {
            await CustomUserManager.CreateAsync(new CustomUser()
            {
                UserName = userName,
                Email = userName
            }, password);
        }
    }
}
