using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadaCode.Security.ViewModels
{
    public class IdeaFormViewModel
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public string Idea { get; set; }

        public int NumberOfVotes { get; set; }
    }
}
