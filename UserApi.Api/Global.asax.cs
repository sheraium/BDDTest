using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using UserApi.Data.Interfaces;
using UserApi.Data.Repositories;

namespace UserApi.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var builder = new ContainerBuilder();
            builder.RegisterType<InMemoryUsersRepository>().As<IUsersRepository>().SingleInstance();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver   = new AutofacWebApiDependencyResolver(container);
        }
    }
}
