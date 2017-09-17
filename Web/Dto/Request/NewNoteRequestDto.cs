namespace Web.Dto.Request
{
    using System.ComponentModel.DataAnnotations;

    public class NewNoteRequestDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string NoteText { get; set; }

        public string Lifetime { get; set; }
    }
}