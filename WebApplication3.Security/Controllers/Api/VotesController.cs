using System.Linq;
using System.Web.Http;
using RadaCode.Entities.Dtos;
using RadaCode.Entities.UserIdea;
using Microsoft.AspNet.Identity;
using RadaCode.Dal;

namespace RadaCode.Security.Controllers.Api
{
    class VotesController : ApiController
    {
        private ApplicationDbContext _context;

        public VotesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Vote(VoteDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Votes.Any(a => a.UserId == userId && a.UserIdeaId == dto.IdeaId))
                return BadRequest("The choice already exists.");

            var vote = new Vote
            {
                UserIdeaId = dto.IdeaId,
                UserId = userId,
                
            };
            _context.Votes.Add(vote);
            _context.SaveChanges();

            return Ok();
        }

    }
}
