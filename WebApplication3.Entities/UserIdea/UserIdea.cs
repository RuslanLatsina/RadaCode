using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RadaCode.Entities.UserIdea
{
    public class UserIdea
    {

        public UserIdea()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Votes = new HashSet<Vote>();
        }

        public int Id { get; set; }
        [Required]
        public string Idea { get; set; }

        public int  NumberOfVotes { get; set; }
        
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
