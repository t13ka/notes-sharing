namespace Web.Dto.Response
{
    using System;

    public class NewNoteResponseDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTimeOffset? Lifetime { get; set; }
    }
}
