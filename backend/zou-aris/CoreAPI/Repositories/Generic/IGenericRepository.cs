﻿using System.Linq.Expressions;

namespace CoreAPI.Repositories.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        T GetOne(Expression<Func<T, bool>> predicate, List<string> includes = null);
        IEnumerable<T> FindAll(List<string> includes = null);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate, List<string> includes = null);

        void Add(T entity);

        void Update(T entity);
        void Remove(T entity);

        void BulkInsert(IEnumerable<T> entities);

        void BulkUpdate(IEnumerable<T> entities);
        void BulkDelete(IEnumerable<T> entities);
    }
}
