using Api.Models;
using DAL.UnitOfWork;
using Services.User;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.API
{
    [AllowAnonymous]
    public class AccountController : ApiController
    {
        private IUserService _userService;
        private IUnitOfWork _unitOfWork;

        public AccountController(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        [Route("api/account/create")]
        public async Task<IHttpActionResult> Register(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userService.AddUser(registerUser.Email);

            _unitOfWork.Commit();

            using (HttpClient httpClient = new HttpClient())
            {
                await httpClient.PostAsync("https://localhost:44300/api/user/register", new StringContent($"'userName': '{registerUser.Email}', 'password': '{registerUser.Password}'"));

                return Ok();
            }

        }
    }
}
