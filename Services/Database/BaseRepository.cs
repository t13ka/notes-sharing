using System;
using System.Collections.Generic;

namespace Services.Database
{
    using System.Linq;
    using System.Linq.Expressions;

    using Core;

    internal class BaseRepository<T> : IRepository<T>
        where T : IEntity
    {
        private static List<T> _collection;

        public BaseRepository()
        {
            _collection = new List<T>();
        }

        public virtual long Count()
        {
            return _collection.Count;
        }

        public virtual void Create(T entity)
        {
            _collection.Add(entity);
        }

        public virtual void Delete(string title)
        {
            var item = _collection.FirstOrDefault(t => t.Title == title);
            if (item != null)
            {
                _collection.Remove(item);
            }
        }

        public virtual IList<T> GetAll()
        {
            return _collection;
        }

        public virtual T GetByTitle(string title)
        {
            return _collection.FirstOrDefault(t => t.Title == title);
        }

        public virtual IList<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            var r = _collection.AsQueryable().Where(predicate.Compile()).ToList();
            return r;
        }

        public virtual void Update(T entity)
        {
            // sorry, this is not truly update. for simplification
            var item = _collection.FirstOrDefault(t => t.Title == entity.Title);
            if (item != null)
            {
                _collection.Remove(item);
                _collection.Add(item);
            }
        }
    }
}