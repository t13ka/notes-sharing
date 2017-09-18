namespace Core
{
    using System.Collections.Generic;

    public interface INoteService
    {
        void Add(NoteRepositoryItem item);

        void Delete(string title);

        NoteRepositoryItem GetByTitle(string title);

        NoteRepositoryItem GetById(string id);

        IEnumerable<NoteRepositoryItem> GetAll();
    }
}