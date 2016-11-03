using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RadaCode.Entities.Identity;

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
        
    }
}
