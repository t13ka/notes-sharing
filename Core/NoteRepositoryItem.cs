namespace Core
{
    using System;

    public class NoteRepositoryItem : IEntity
    {
        public string Id { get; set; }

        public string Title { get; set; }
       
        public string Text { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTimeOffset? Lifetime { get; set; }

        public bool IsAlreadyExpired()
        {
            if (Lifetime < DateTime.UtcNow)
            {
                return true;
            }

            return false;
        }
    }
}
