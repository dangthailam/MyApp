using IdentityServer3.AccessTokenValidation;
using Microsoft.Owin.Cors;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Allow all origins
            app.UseCors(CorsOptions.AllowAll);

            // Wire token validation
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44300/core",

                // For access to the introspection endpoint
                ClientId = "api",
                ClientSecret = "api-secret",
                RequiredScopes = new[] { "api" },
                
            });

            // Wire Web API

        }
    }
}
