namespace RestConGraph
{
    using Core;
    using Handlers;
    using System.Web.Http;
    using Unity;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MessageHandlers.Add(new CryptoHandler());

            config.MapHttpAttributeRoutes();

            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var contenedor = new UnityContainer();
            Peliculas.MySQL.Contenedor.Registrar(contenedor);
            Contenedor.Registrar(contenedor);
            config.DependencyResolver = new UnityResolver(contenedor);
        }
    }
}