using DnD_Board.Data.Models;
using System;

namespace DnD_Board.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : BaseModel;

        int Complete();
    }
}