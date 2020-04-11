using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using VehicleManagementSystemApi.Infrastructure;
using VehicleManagementSystemBusiness.Configuration;

namespace VehicleManagementSystemApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.Initialize();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterExceptionFilters(GlobalConfiguration.Configuration.Filters);
        }

        public static void RegisterExceptionFilters(HttpFilterCollection filters)
        {
            filters.Add(new GenericExceptionFilterAttribute());
        }
    }
}
