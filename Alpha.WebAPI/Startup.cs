using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Alpha.WebAPI.Startup))]
namespace Alpha.WebAPI {
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
