using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.API
{
    [Route("values")]
    //[Authorize]
    public class ValuesController : ApiController
    {
        public IEnumerable<string> Get()
        {
            var random = new Random();

            return new[]
            {
                random.Next(0, 10).ToString(),
                random.Next(0, 10).ToString()
            };
        }
    }
}
