﻿using System.Web.Http;
using Swashbuckle.Application;
using System.Web.Http.Routing;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;

namespace Swashbuckle
{
    public static class Bootstrapper
    {
        public static void Init(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                "swagger_root",
                "swagger",
                null,
                null,
                new RedirectHandler("swagger/ui/index.html"));

            config.Routes.MapHttpRoute(
                "swagger_ui",
                "swagger/ui/{*uiPath}",
                null,
                new { uiPath = @".+" },
                new SwaggerUiHandler());

            config.Routes.MapHttpRoute(
                "swagger_versioned_api_docs",
                "swagger/{apiVersion}/api-docs/{resourceName}",
                new { resourceName = RouteParameter.Optional },
                null,
                new SwaggerSpecHandler());

            config.Routes.MapHttpRoute(
                "swagger_api_docs",
                "swagger/api-docs/{resourceName}",
                new { resourceName = RouteParameter.Optional },
                null,
                new SwaggerSpecHandler());
        }
    }
}