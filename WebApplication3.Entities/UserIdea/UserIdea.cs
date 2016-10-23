using System.Collections.Generic;

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
        public string Idea { get; set; }
        
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
