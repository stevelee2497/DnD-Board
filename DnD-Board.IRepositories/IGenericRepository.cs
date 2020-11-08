using DnD_Board.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DnD_Board.IRepositories
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        T Add(T entity);

        IEnumerable<T> AddRange(IEnumerable<T> entities);

        IEnumerable<T> All();

        IEnumerable<T> Where(Expression<Func<T, bool>> predicate);

        T Find(Guid id);

        T First(Expression<Func<T, bool>> predicate);

        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        bool Any();

        bool Any(Expression<Func<T, bool>> predicate);

        int Count(Expression<Func<T, bool>> predicate);

        int Count();

        T Remove(T entity);

        IEnumerable<T> RemoveRange(IEnumerable<T> entity);

        T DeActivate(T entity);

        IEnumerable<T> DeActivateRange(IEnumerable<T> entities);

        T Activate(T entity);

        IEnumerable<T> ActivateRange(IEnumerable<T> entities);

        T Update(T entity);

        IEnumerable<T> UpdateRange(IEnumerable<T> entities);
    }
}