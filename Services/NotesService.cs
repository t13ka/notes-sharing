namespace Services
{
    using System;
    using System.Collections.Generic;

    using Core;

    using Services.Database;

    public class NotesService : INoteService
    {
        private readonly NotesRepository _notesRepository;

        public NotesService()
        {
            _notesRepository = new NotesRepository();
        }

        public static string GenerateId()
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty);
        }

        public static DateTimeOffset? GetDateTimeOffsetValue(string key)
        {
            DateTimeOffset? dateTimeOffset;

            if (string.IsNullOrEmpty(key))
            {
                key = "Never";
            }

            var dateTimeOffsets =
                new Dictionary<string, DateTimeOffset?>
                    {
                        { "Never", null },
                        { "10 minutes", DateTimeOffset.UtcNow.AddMinutes(10) },
                        { "1 hour", DateTimeOffset.UtcNow.AddHours(1) },
                        { "1 day", DateTimeOffset.UtcNow.AddDays(1) },
                        { "1 week", DateTimeOffset.UtcNow.AddDays(7) },
                        { "1 month", DateTimeOffset.UtcNow.AddMonths(1) },
                    };

            if (dateTimeOffsets.TryGetValue(key, out dateTimeOffset))
            {
                return dateTimeOffset;
            }

            return null;
        }

        public void Add(NoteRepositoryItem item)
        {
            _notesRepository.Create(item);
        }

        public void Delete(string title)
        {
            _notesRepository.Delete(title);
        }

        public NoteRepositoryItem GetByTitle(string title)
        {
            return _notesRepository.GetByTitle(title);
        }

        public NoteRepositoryItem GetById(string id)
        {
            return _notesRepository.GetById(id);
        }

        public IEnumerable<NoteRepositoryItem> GetAll()
        {
            return _notesRepository.GetAll();
        }
    }
}