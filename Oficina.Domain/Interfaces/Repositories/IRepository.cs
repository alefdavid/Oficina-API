﻿using OficinaOS.Domain.Entities;

namespace OficinaOS.Domain.Interfaces.Repositories
{
    public interface IRepository<T> : IDisposable where T : Entity, new()
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task<bool> Delete(int id);
        void Add(T entity);
        void Put(T entity);
    }
}
