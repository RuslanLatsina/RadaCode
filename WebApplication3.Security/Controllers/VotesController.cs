using Microsoft.AspNet.Identity;
using RadaCode.Dal;
using RadaCode.Entities.UserIdea;
using RadaCode.Security.ViewModels;
using System.Linq;
using System.Web.Http;

namespace RadaCode.Security.Controllers
{
    [Authorize]
    public class VotesController : ApiController
    {
        private ApplicationDbContext _context;

        public VotesController()
        {
            _context = new ApplicationDbContext();
            
        }
        [HttpPost]
        [Route("api/Votes")]
        public IHttpActionResult Votes([FromBody] VoteViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Votes.Any(a => a.UserId == userId && a.UserIdeaId == viewModel.IdeaId))
                return BadRequest("The choice already exists.");

            var vote = new Vote
            {
                UserIdeaId = viewModel.IdeaId,
                UserId = userId,
                IsLike = viewModel.IsLike

            };
            _context.Votes.Add(vote);
            _context.SaveChanges();

            return Ok();
        }

    }
}
