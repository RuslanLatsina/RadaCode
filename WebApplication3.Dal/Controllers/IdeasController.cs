using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RadaCode.Entities.Models.Identity;
using RadaCode.Entities.Models.UserIdea;
using RadaCode.Entities.ViewModels;

namespace RadaCode.Dal.Controllers
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
        public ActionResult LikeIdeas()
        {
            var userId = IdentityExtensions.GetUserId(User.Identity);
            var votes = Queryable.Where<Vote>(_context.Votes, a => a.UserId == userId && a.IsLike);
            var userIdeas = QueryableExtensions.Include<UserIdea, ApplicationUser>(_context.Ideas, g => g.User)
                .Include(g => g.Votes)
                .Where(g => g.Votes.FirstOrDefault(a => a.UserId == userId).IsLike);


            var viewModel = new IdeasViewModel()
            {
                UserIdeas = userIdeas,
                ShowActions = User.Identity.IsAuthenticated,
                Votes = votes,
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
                UserId = IdentityExtensions.GetUserId(User.Identity),
                Idea = viewModel.Idea,
                NumberOfVotes   = 0
            };
            _context.Ideas.Add(idea);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        
        public ActionResult Votes(VoteViewModel viewModel)
        {
            var userId = IdentityExtensions.GetUserId(User.Identity);
            

            if (Queryable.Any<Vote>(_context.Votes, a => a.UserId == userId && a.UserIdeaId == viewModel.IdeaId))
                return Redirect("The choice already exists.");

            var vote = new Vote
            {
                UserIdeaId = viewModel.IdeaId,
                UserId = userId,
                IsLike = viewModel.IsLike

            };
            _context.Votes.Add(vote);
            _context.SaveChanges();

            return RedirectToAction("Index","Home");




        }

    }
}