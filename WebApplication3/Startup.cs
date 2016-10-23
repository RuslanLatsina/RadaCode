using System.Security;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Owin;
using Owin;
using SimpleInjector.Integration.Web.Mvc;
using RadaCode.Dal;
using RadaCode.Dal.Managers;

[assembly: OwinStartup(typeof(RadaCode.Startup))]
namespace RadaCode
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var container = ContainerConfig.Configure();
            app.UseSimpleInjectorContext(container);
            app.CreatePerOwinContext(container.GetInstance<ApplicationDbContext>);
            app.CreatePerOwinContext(container.GetInstance<ApplicationUserManager>);
            app.CreatePerOwinContext(container.GetInstance<ApplicationSignInManager>);
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            app.ConfigureAuth();
        }
    }
}
