﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LGroup.Integracao.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //HABILITAMOS CHATIVAMOS NO NOSSO PROJETO
            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

