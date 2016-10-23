using Microsoft.AspNet.Identity;
using RadaCode.Entities.Identity;

namespace RadaCode.Dal.Managers
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }
    }
}