using System.ComponentModel.DataAnnotations;

namespace Notes_Website.Models
{
    public class AmendmentModel
    {
        [Key]
        public int Id { get; set; }

        //This stores the title for the addition
        [Required (ErrorMessage = "Either no admendment title was added or the title isn't between 5 to 20 characters.")]
        [StringLength(20, MinimumLength = 5)]
        [Display(Name = "Admendment Name")]
        public string? Title { get; set; }

        //This stores the date the addition was made
        [Required(ErrorMessage = "A date wasn't added.")]
        [Display(Name = "Note Added Date")]
        public DateTime? Date { get; set; }

        //This stores who made the addition
        [Required(ErrorMessage = "Either no name was added or the name is too short.")]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Author")]
        public string? Author { get; set; }

        //This stores the actual note of the addition
        [Required(ErrorMessage = "Either no admendment was added or the admendment isn't between 5 to 500 characters.")]
        [StringLength(500, MinimumLength = 5)]
        [Display(Name = "The Admendment")]
        public string? Details { get; set; }

        //This stores where the addtion falls in the sequance of additions
        [Required(ErrorMessage = "The part of the note was not indicated.")]
        [Display(Name = "Note Continuation")]
        public int? Note_Part { get; set; } //Lets the user know the order of their Admendment

        public int NoteModelId { get; set; }

        public NoteModel? Note { get; set; }
    }
}
