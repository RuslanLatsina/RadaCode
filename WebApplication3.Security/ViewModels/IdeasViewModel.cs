using RadaCode.Entities.UserIdea;
using System.Collections.Generic;
using System.Linq;

namespace RadaCode.Security.ViewModels
{
    public class IdeasViewModel
    {
        public IEnumerable<UserIdea> UserIdeas { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public IEnumerable<Vote> Votes { get; set; }
    }
}
