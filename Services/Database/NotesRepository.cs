namespace Services.Database
{
    using System;

    using Core;

    /// <summary>
    /// The notes repository.
    /// </summary>
    internal sealed class NotesRepository : BaseRepository<NoteRepositoryItem>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRepository"/> class.
        /// </summary>
        public NotesRepository()
        {
            //for (var i = -3; i < 20; i++)
            //{
            //    var utcNow = DateTime.UtcNow;
            //    var presetItem = new NoteRepositoryItem
            //                         {
            //                             Id = NotesService.GenerateId(),
            //                             CreateDateTime = utcNow.AddMinutes(i),
            //                             Title = $"Some title of note {i}",
            //                             Text = $"Some text {i}",
            //                             Lifetime = utcNow.AddMinutes(i)
            //                         };
            //    Create(presetItem);
            //}
        }
    }
}