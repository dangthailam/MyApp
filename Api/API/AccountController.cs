using App.Services.User;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.API
{
    [AllowAnonymous]
    public class AccountController : ApiController
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
    }
}
