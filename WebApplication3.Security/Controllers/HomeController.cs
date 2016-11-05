using System;
using System.Web.Mvc;
using RadaCode.Dal;
using RadaCode.Security.ViewModels;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace RadaCode.Security.Controllers
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
            var userId = User.Identity.GetUserId();
            var userIdeas = _context.Ideas.Include(g => g.User).Include(g => g.Votes);
            var votes = _context.Votes.Where(a => a.UserId == userId);

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