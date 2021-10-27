using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Interfaces
{
    public interface IRepository<T>  where T : class 
    {
        IQueryable<T> GetAll();
        void Add(T item);
        void Update(T item);
        void Remove(int id);
        void Save();
    }
}