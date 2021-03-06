﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RadaCode.Entities.Models.Identity;

namespace RadaCode.Entities.Models.UserIdea
{
    public class Vote
    {
        [Key, Column(Order = 0)]
        [Required]
        public int UserIdeaId { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        public string UserId { get; set; }

        public bool IsLike { get; set; }

        public virtual UserIdea UserIdea { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
