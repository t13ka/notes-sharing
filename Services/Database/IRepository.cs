namespace Services.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Core;

    internal interface IRepository<T>
        where T : IEntity
    {
        long Count();

        void Create(T entity);
       
        void Delete(string title);
       
        IList<T> GetAll();

        T GetByTitle(string title);

        IList<T> SearchFor(Expression<Func<T, bool>> predicate);

        void Update(T entity);
    }
}
