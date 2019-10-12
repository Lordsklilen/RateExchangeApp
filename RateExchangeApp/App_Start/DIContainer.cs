using Autofac;
using Autofac.Integration.WebApi;
using RateExchangeApp.Core;
using RateExchangeApp.Repository;
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
        public static IContainer container;
        public static void BuildContainer() {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ExchangeLogic>().As<IExchangeLogic>();
            builder.RegisterType<CurrencyConverter>().As<ICurrencyConverter>();
            builder.RegisterType<NbpRepository>().As<INbpRepository>();
            builder.RegisterType<LogRepository>().As<ILogRepository>();
            container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}