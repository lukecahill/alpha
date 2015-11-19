using Alpha.WebAPI.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartupAttribute(typeof(Alpha.WebAPI.Startup))]
namespace Alpha.WebAPI {
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            
            ConfigureOAth(app);

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            //ConfigureAuth(app);
        }

        public void ConfigureOAth(IAppBuilder app) {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions() {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
