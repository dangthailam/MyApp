using IdentityManager.Configuration;
using IdentityManager.Core.Logging;
using IdentityManager.Logging;
using IdentityServer.Context;
using IdentityServer.Crtfc;
using IdentityServer.UserService;
using IdentityServer3.Core.Configuration;
using Owin;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<CustomUserManager>(CustomUserManager.Create);
            app.CreatePerOwinContext<CustomSignInManager>(CustomSignInManager.Create);

            LogProvider.SetCurrentLogProvider(new DiagnosticsTraceLogProvider());
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Trace()
               .CreateLogger();

            app.Map("/admin", adminApp =>
            {
                var factory = new IdentityManagerServiceFactory();
                factory.ConfigureCustomIdentityManagerService();

                adminApp.UseIdentityManager(new IdentityManagerOptions()
                {
                    Factory = factory
                });
            });

            app.Map("/core", core =>
            {
                var idSvrFactory = Factory.Configure();
                idSvrFactory.ConfigureCustomUserService();

                var options = new IdentityServerOptions
                {
                    SiteName = "IdentityServer3 - UserService-AspNetIdentity",
                    SigningCertificate = Certificate.Get(),
                    Factory = idSvrFactory,
                    AuthenticationOptions = new AuthenticationOptions
                    {
                        IdentityProviders = ConfigureAdditionalIdentityProviders,
                    }
                };

                core.UseIdentityServer(options);
            });

            var httpConfiguration = new HttpConfiguration();
            httpConfiguration.MapHttpAttributeRoutes();

            httpConfiguration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(httpConfiguration);

            //app.UseIdentityServer(new IdentityServerOptions
            //{
            //    SiteName = "Embedded IdentityServer",
            //    SigningCertificate = LoadCertificate(),

            //    Factory = new IdentityServerServiceFactory()
            //        .UseInMemoryUsers(Users.Get())
            //        .UseInMemoryClients(Clients.Get())
            //        .UseInMemoryScopes(Scopes.Get())
            //});
        }

        public static void ConfigureAdditionalIdentityProviders(IAppBuilder app, string signInAsType)
        {
            //var google = new GoogleOAuth2AuthenticationOptions
            //{
            //    AuthenticationType = "Google",
            //    SignInAsAuthenticationType = signInAsType,
            //    ClientId = "767400843187-8boio83mb57ruogr9af9ut09fkg56b27.apps.googleusercontent.com",
            //    ClientSecret = "5fWcBT0udKY7_b6E3gEiJlze"
            //};
            //app.UseGoogleAuthentication(google);

            //var fb = new FacebookAuthenticationOptions
            //{
            //    AuthenticationType = "Facebook",
            //    SignInAsAuthenticationType = signInAsType,
            //    AppId = "676607329068058",
            //    AppSecret = "9d6ab75f921942e61fb43a9b1fc25c63"
            //};
            //app.UseFacebookAuthentication(fb);

            //var twitter = new TwitterAuthenticationOptions
            //{
            //    AuthenticationType = "Twitter",
            //    SignInAsAuthenticationType = signInAsType,
            //    ConsumerKey = "N8r8w7PIepwtZZwtH066kMlmq",
            //    ConsumerSecret = "df15L2x6kNI50E4PYcHS0ImBQlcGIt6huET8gQN41VFpUCwNjM"
            //};
            //app.UseTwitterAuthentication(twitter);
        }

        //X509Certificate2 LoadCertificate()
        //{
        //    return new X509Certificate2(
        //        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\idsrv3test.pfx"), "idsrv3test");
        //}
    }
}
