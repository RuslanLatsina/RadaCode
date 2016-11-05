using System.Collections.Generic;
using System.Collections.ObjectModel;
using RadaCode.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace RadaCode.Entities.UserIdea
{
    public class UserIdea
    {

        public int Id { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Idea { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        public int  NumberOfVotes { get; set; }
        public ICollection<Vote> Votes { get; private set; }

        public UserIdea()
        {
            Votes = new Collection<Vote>();
        }
    }
}
