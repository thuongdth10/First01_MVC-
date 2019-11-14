using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        private First01_MVCDBContext dbContext;
        protected First01_MVCDBContext DbContext
        {
            get
            {
                if (dbContext == null)
                {
                    dbContext = DbFactory.Init();
                }
                return dbContext;
            }
        }
        private readonly DbSet<T> dbSet;
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }
        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }
        //void Add(T entity);
        //void Update(T entity);
        //void Delete(T entity);
        //IQueryable<T> GetAll();
        //T GetById(int id);
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Update(entity);
        }
        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }
        public virtual T GetById(int id)
        {
           return dbSet.Find(id);
        }
        public virtual IQueryable<T> GetAll()
        {
            return dbSet;
        }
    }
}
