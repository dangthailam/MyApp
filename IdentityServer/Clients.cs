using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                new Client
                {
                    Enabled = true,
                    ClientName = "JS Client",
                    ClientId = "js",
                    Flow = Flows.Implicit,

                    RedirectUris = new List<string>
                    {
                        "http://localhost:55505/index.html"
                    },

                    // Valid URLs after logging out
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:55505/index.html"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "http://localhost:55505"
                    },
                    AllowAccessToAllScopes = true,
                    AccessTokenLifetime = 70,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    }
                }
            };
        }
    }
}
