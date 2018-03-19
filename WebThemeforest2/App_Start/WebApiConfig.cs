using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

class WebApiConfig
{
    public static void Register(HttpConfiguration configuration)
    {
        //configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
        //    new { id = RouteParameter.Optional });

        //configuration.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{id}",
        //        defaults: new { id = RouteParameter.Optional }
        //    );


        configuration.MapHttpAttributeRoutes();
        configuration.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
        EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
        configuration.EnableCors(cors);
        
        configuration.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html")); 
    }
}