using MyApp.Services.User;
using MyApplication.PrivateAPI.IdentityServerUserManagement;
using MyApplication.PrivateAPI.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyApplication.PrivateAPI.Controller
{
    [AllowAnonymous]
    [RoutePrefix("private/api/user")]
    [EnableCors(origins: "http://localhost:55505", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private IUserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        [Route("register")]
        public async Task<IHttpActionResult> Register(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userService.AddUser(registerUser.Email);

            using (WCFUserManagementServiceClient identityServerUserService = new WCFUserManagementServiceClient())
            {
                await identityServerUserService.RegisterAsync(registerUser.Email, registerUser.Password);

                return Ok();
            }

        }

    }
}
