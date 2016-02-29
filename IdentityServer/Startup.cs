using IdentityServer3.Core.Configuration;
using Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServer(new IdentityServerOptions
            {
                SiteName = "Embedded IdentityServer",
                SigningCertificate = LoadCertificate(),
                
                Factory = new IdentityServerServiceFactory()
                    .UseInMemoryUsers(Users.Get())
                    .UseInMemoryClients(Clients.Get())
                    .UseInMemoryScopes(Scopes.Get())
            });
        }

        X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\idsrv3test.pfx"), "idsrv3test");
        }
    }
}
