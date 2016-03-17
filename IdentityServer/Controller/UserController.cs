using IdentityServer.Context;
using IdentityServer.Models;
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

        public CustomUserManager CustomUserManager { get
            {
                if(_customUserManager == null)
                {
                    _customUserManager = Request.GetOwinContext().GetUserManager<CustomUserManager>();
                }
                return _customUserManager;
            }
        }

        [Route("register")]
        [HttpPost]
        public async Task<IHttpActionResult> Register(RegisterUserViewModel createUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new CustomUser()
            {
                UserName = createUserModel.Email,
                Email = createUserModel.Email
            };

            IdentityResult addUserResult = await CustomUserManager.CreateAsync(user, createUserModel.Password);

            if (!addUserResult.Succeeded)
            {
                return GetErrorResult(addUserResult);
            }

            Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

            return Created(locationHeader, addUserResult);
        }
    }
}
