using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using RadaCode.Dal;
using RadaCode.Dal.Managers;
using RadaCode.Entities.Models.Identity;

namespace RadaCode
{
    public static class ContainerConfig
    {
        public static Container Configure()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();


            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.RegisterPerWebRequest<IUserStore<ApplicationUser>, ApplicationUserStore>();
            container.RegisterPerWebRequest<ApplicationUserManager>();
            container.RegisterPerWebRequest(() => container.IsVerifying ? new OwinContext(new Dictionary<string, object>()).Authentication : HttpContext.Current.GetOwinContext().Authentication);
            container.RegisterPerWebRequest<ApplicationSignInManager>();
            container.Register<IIdentityValidator<string>>(() => new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = false,
                RequireUppercase = false,
            }, Lifestyle.Singleton);

            container.RegisterInitializer<ApplicationUserManager>(manager =>
            {
                manager.UserValidator = new UserValidator<ApplicationUser>(manager)
                {
                    AllowOnlyAlphanumericUserNames = false,
                    RequireUniqueEmail = true
                };

                // Configure validation logic for passwords
                manager.PasswordValidator = container.GetInstance<IIdentityValidator<string>>();

                // Configure user lockout defaults
                manager.UserLockoutEnabledByDefault = true;
                manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
                manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            });

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();

            return container;
        }
    }
}