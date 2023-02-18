using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CreditCard.Core.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            var cors = new EnableCorsAttribute(
            origins: "*",
            headers: "*",
            methods: "*");

            cors.SupportsCredentials = true;
            cors.PreflightMaxAge = 6000;
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
