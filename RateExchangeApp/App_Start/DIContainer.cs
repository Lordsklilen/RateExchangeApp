using Autofac;
using Autofac.Integration.WebApi;
using RateExchangeApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace RateExchangeApp.App_Start
{
    public class DIContainer
    {
        public static void BuildContainer() {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ExchangeLogic>().As<IExchangeLogic>();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}