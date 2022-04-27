using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Notes_Website.Models
{
    public class NoteModel
    {
        [Key]
        public int Id { get; set; } //Used to make column in DB that holds holds the primary key

        [Required (ErrorMessage = "Either no title was added or the title isn't between 5 to 20 characters.")]
        [StringLength(20, MinimumLength = 5)]
        [Display(Name = "Note Title")]
        public string Title { get; set; } = string.Empty; //Used to make column in DB that holds the note's title

        [Required (ErrorMessage = "Either no note was added or the note isn't between 5 to 500 characters.")]
        [StringLength(500, MinimumLength = 5)]
        [Display(Name = "Your Note")]
        public string Note { get; set; } = string.Empty; //Used to make column in DB that holds the notes information

        [Required(ErrorMessage = "A date wasn't added.")]
        [Display(Name = "Note Added Date")]
        public DateTime Added { get; set; } //Used to make column in DB that holds holds when the note was created or edited

        [Required(ErrorMessage = "The part of the note was not indicated.")]
        [Display(Name = "Note Continuation")]
        public int Note_Part { get; set; } = 0; //Lets the user know the order of their notes

        [Required(ErrorMessage = "Please select a note type")]
        [Display(Name = "Type of Note")]
        public int NoteTypeId { get; set; }

        public NoteType? NoteType { get; set; }
    }
}
