using System.ComponentModel.DataAnnotations;

namespace RadaCode.Entities.ViewModels
{
    public class IdeaFormViewModel
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public string Idea { get; set; }

        public int NumberOfVotes { get; set; }
    }
}
