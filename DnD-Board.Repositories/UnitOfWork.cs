using DnD_Board.Data.Contexts;
using DnD_Board.Data.Models;
using DnD_Board.IRepositories;
using System;
using System.Collections.Generic;

namespace DnD_Board.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EfDbContext Context;
        private readonly Dictionary<Type, object> Repositories;
        private bool _disposed;

        public UnitOfWork(EfDbContext context)
        {
            Context = context;
            Repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<T> Repository<T>() where T : BaseModel
        {
            var type = typeof(T);
            if (!Repositories.ContainsKey(type))
            {
                Repositories[type] = new GenericRepository<T>(Context);
            }

            return (IGenericRepository<T>)Repositories[type];
        }

        public int Complete()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (Repositories != null)
                    {
                        Repositories.Clear();
                    }

                    Context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
