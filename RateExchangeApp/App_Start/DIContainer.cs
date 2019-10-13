using Autofac;
using Autofac.Integration.WebApi;
using RateExchangeApp.Core;
using RateExchangeApp.Repository;
using System.Reflection;
using System.Web.Http;
using RateExchangeApp.Core.Logger;
using System.Web.Configuration;
using System;

namespace RateExchangeApp.App_Start
{
    public class DIContainer
    {
        public static IContainer container;
        public static void BuildContainer() {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            bool UseLogsToDB = Convert.ToBoolean(WebConfigurationManager.AppSettings["UseLogsToDB"]);

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<ExchangeLogic>().As<IExchangeLogic>();
            builder.RegisterType<CurrencyConverter>().As<ICurrencyConverter>();
            builder.RegisterType<NbpRepository>().As<INbpRepository>();
            builder.RegisterType<LogRepository>().As<ILogRepository>();
            if(UseLogsToDB)
                builder.RegisterType<Logger>().As<ILogger>();
            else
                builder.RegisterType<EmptyLogger>().As<ILogger>();

            container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}