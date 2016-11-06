using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RadaCode.Entities.Models.Identity;
using RadaCode.Entities.Models.UserIdea;
using RadaCode.Entities.ViewModels;

namespace RadaCode.Dal.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var regdate = new DateTime(2015, 12, 1);
            var nowdate = new DateTime(2015, 12, 12);
            var number = 10 + ((int)(nowdate - regdate).TotalDays / 3);

            var userId = IdentityExtensions.GetUserId(User.Identity);
            var userIdeas = QueryableExtensions.Include<UserIdea, ApplicationUser>(_context.Ideas, g => g.User).Include(g => g.Votes);
            var votes = Queryable.Where<Vote>(_context.Votes, a => a.UserId == userId);

            var viewModel = new IdeasViewModel
            {
                UserIdeas = userIdeas,
                ShowActions = User.Identity.IsAuthenticated,
                Votes = votes,
                Heading = "User Ideas"
            };



            return View("Ideas", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}