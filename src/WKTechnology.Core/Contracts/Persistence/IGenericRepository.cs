﻿namespace WKTechnology.Core.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Get(int id);        
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}