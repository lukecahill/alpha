using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Practices.Unity;
using Alpha.Interfaces.Interfaces;
using Alpha.BusinessLogic.Repositories;
using System.Net.Http.Headers;

namespace Alpha.WebAPI {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IPublisherRepository, PublisherRepository>(new HierarchicalLifetimeManager());
            container.Resolve<IPublisherRepository>();

            container.RegisterType<IGamesRepository, GamesRepository>(new HierarchicalLifetimeManager());
            container.Resolve<IGamesRepository>();

            container.RegisterType<IAddonsRepository, AddonsRepository>(new HierarchicalLifetimeManager());
            container.Resolve<IAddonsRepository>();

            container.RegisterType<IAccessoriesRepository, AccessoriesRepository>(new HierarchicalLifetimeManager());
            container.Resolve<IAccessoriesRepository>();

            config.DependencyResolver = new UnityResolver(container);

            //config.EnableSystemDiagnosticsTracing();
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
