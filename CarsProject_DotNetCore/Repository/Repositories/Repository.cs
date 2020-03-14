using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.Repositories;


namespace Repository.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private int NumberOfEntities_getAll = 10;
        protected readonly DbContext context;
        public Repository(DbContext context)
        {
            this.context = context;
        }

        public TEntity Get(Guid id)
        {
            return this.context.Set<TEntity>().Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return this.context.Set<TEntity>().Take(this.NumberOfEntities_getAll).ToList();  // Add OrderBy(date) before Take method
        }
        public void Add(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
        }
        public void Update(TEntity entity)
        {
            this.context.Set<TEntity>().Update(entity);
        }
        public void Remove(TEntity entity)
        {
            this.context.Set<TEntity>().Remove(entity);
        }
        
    }
}