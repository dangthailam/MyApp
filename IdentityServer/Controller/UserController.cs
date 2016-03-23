using IdentityServer.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace IdentityServer.Controller
{
    [RoutePrefix("api/user")]
    public class UserController : BaseApiController
    {
        private CustomUserManager _customUserManager;

        public CustomUserManager CustomUserManager
        {
            get
            {
                if (_customUserManager == null)
                {
                    _customUserManager = Request.GetOwinContext().GetUserManager<CustomUserManager>();
                }
                return _customUserManager;
            }
        }

        [Route("register")]
        [HttpPost]
        public async Task<IHttpActionResult> Register(string userName, string password)
        {
            IdentityResult addUserResult = await CustomUserManager.CreateAsync(new CustomUser()
            {
                UserName = userName,
                Email = userName
            }, password);

            if (!addUserResult.Succeeded)
            {
                return GetErrorResult(addUserResult);
            }

            return Ok();
        }
    }
}
