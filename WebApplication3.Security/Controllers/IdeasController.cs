using Microsoft.AspNet.Identity;
using RadaCode.Dal;
using RadaCode.Entities.UserIdea;
using RadaCode.Security.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace RadaCode.Security.Controllers
{
    public class IdeasController : Controller
    {
        private ApplicationDbContext _context;

        public IdeasController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        public ActionResult LikeVotes()
        {
            var userId = User.Identity.GetUserId();
            var ideas = _context.Votes
                .Where(a => a.UserId == userId && a.IsLike == true)
                .Select(a => a.UserIdea)
                .Include(g => g.User)
                .ToList();

            var viewModel = new IdeasViewModel()
            {
                UserIdeas = ideas,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Like Ideas"
            };

            return View("Ideas", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IdeaFormViewModel viewModel)
        {
            if(!ModelState.IsValid)
                return View("Create", viewModel);
            var idea = new UserIdea
            {
                UserId = User.Identity.GetUserId(),
                Idea = viewModel.Idea,
                NumberOfVotes   = 0
            };
            _context.Ideas.Add(idea);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}