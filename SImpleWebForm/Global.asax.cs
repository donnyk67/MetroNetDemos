using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using CommonLibrary.PlayingCardFactory;
using SimpleWebForm.ControllerHelpers;
using SimpleWebForm.Controllers;
using SimpleWebForm.StaticHelpers;

namespace SImpleWebForm
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //***Note*** for now just use player one
            //GameCredits.ResetUserCredits();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // Register MVC-related dependencies
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModule<AutofacWebTypesModule>();

            // Register 
            builder.RegisterType<PlayingCardFactory>().As<IPlayingCardFactory>().InstancePerHttpRequest();
            builder.RegisterType<HelperClass>().As<IHelperClass>().InstancePerHttpRequest();
            builder.RegisterModelBinderProvider();

            // Set the MVC dependency resolver to use Autofac
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
