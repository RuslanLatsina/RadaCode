using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;

namespace RadaCode.Security.ViewModels
{
    public class VoteViewModel
    {
        public int IdeaId { get; set; }
        public bool IsLike { get; set; }
    }
}
