using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.API
{
    public class AccountController : ApiController
    {
        [Route("api/account/create")]
        public IHttpActionResult Register()
        {
            return Ok();
        }
    }
}
