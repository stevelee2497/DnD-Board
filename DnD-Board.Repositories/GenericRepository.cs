using DnD_Board.Data.Models;
using DnD_Board.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DnD_Board.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        protected readonly DbContext Context;
        private readonly DbSet<T> Table;

        public GenericRepository(DbContext context)
        {
            Context = context;
            Table = Context.Set<T>();
        }

        public IIncludableQueryable<T, TProperty> Include<TProperty>(Expression<Func<T, TProperty>> navigationPropertyPath)
        {
            return Table.Include(navigationPropertyPath);
        }

        public T Add(T entity)
        {
            return Table.Add(OnCreate(entity)).Entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            return entities.Select(x => Table.Add(OnCreate(x)).Entity);
        }

        public IEnumerable<T> All()
        {
            return Table.Where(x => x.IsActive).AsEnumerable();
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(x => x.IsActive).Any(predicate);
        }

        public bool Any()
        {
            return Table.Where(x => x.IsActive).Any();
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(x => x.IsActive).Count(predicate);
        }

        public int Count()
        {
            return Table.Count(x => x.IsActive);
        }

        public T Find(Guid id)
        {
            var res = Table.Find(id);
            return res?.IsActive == true ? res : null;
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(x => x.IsActive).First(predicate);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(x => x.IsActive).FirstOrDefault(predicate);
        }

        public T Remove(T entity)
        {
            return Table.Remove(entity).Entity;
        }

        public IEnumerable<T> RemoveRange(IEnumerable<T> entities)
        {
            return entities.Select(x => Table.Remove(x).Entity);
        }

        public T Activate(T entity)
        {
            return Table.Update(OnActivate(entity)).Entity;
        }

        public IEnumerable<T> ActivateRange(IEnumerable<T> entities)
        {
            return entities.Select(x => Table.Update(OnActivate(x)).Entity);
        }

        public T DeActivate(T entity)
        {
            return Table.Update(OnDeActivate(entity)).Entity;
        }

        public IEnumerable<T> DeActivateRange(IEnumerable<T> entities)
        {
            return entities.Select(x => Table.Update(OnDeActivate(x)).Entity);
        }

        public T Update(T entity)
        {
            return Table.Update(OnUpdate(entity)).Entity;
        }

        public IEnumerable<T> UpdateRange(IEnumerable<T> entities)
        {
            return entities.Select(x => Table.Update(OnUpdate(x)).Entity);
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate);
        }

        private T OnCreate(T entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedTime = DateTime.Now;
            entity.UpdatedTime = DateTime.Now;
            entity.IsActive = true;
            return entity;
        }

        private T OnUpdate(T entity)
        {
            entity.UpdatedTime = DateTime.Now;
            return entity;
        }

        private T OnDeActivate(T entity)
        {
            entity.IsActive = false;
            entity.UpdatedTime = DateTime.Now;
            return entity;
        }

        private T OnActivate(T entity)
        {
            entity.IsActive = false;
            entity.UpdatedTime = DateTime.Now;
            return entity;
        }
    }
}
