using Autofac;
using Autofac.Integration.WebApi;
using CommonLibrary.PlayingCardFactory;
using System.Reflection;
using System.Web.Http;

namespace SimpleWebApi.App_Start
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<PlayingCardFactory>()
                .As<IPlayingCardFactory>()
                .InstancePerRequest();


            Container = builder.Build();

            return Container;
        }

    }
}