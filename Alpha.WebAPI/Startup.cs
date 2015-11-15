using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;



[assembly: OwinStartupAttribute(typeof(Alpha.WebAPI.Startup))]
namespace Alpha.WebAPI {
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
            //ConfigureAuth(app);
        }
    }
}
