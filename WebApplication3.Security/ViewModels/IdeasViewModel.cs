using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RadaCode.Entities.UserIdea;

namespace RadaCode.Security.ViewModels
{
    public class IdeasViewModel
    {
        public IEnumerable<UserIdea> UserIdeas { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
    }
}
