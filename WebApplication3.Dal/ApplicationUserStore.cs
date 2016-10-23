using Microsoft.AspNet.Identity.EntityFramework;
using RadaCode.Entities.Identity;

namespace RadaCode.Dal
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext context) : base(context)
        {

        }
    }
}
