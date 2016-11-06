using System.Collections.Generic;
using RadaCode.Entities.Models.UserIdea;

namespace RadaCode.Entities.ViewModels
{
    public class IdeasViewModel
    {
        public IEnumerable<UserIdea> UserIdeas { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
        public IEnumerable<Vote> Votes { get; set; }
    }
}
