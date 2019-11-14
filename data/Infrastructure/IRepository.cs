using System;
using System.Linq;

namespace data.Infrastructure
{
   public interface IRepository<T> where T : class
    {
        //1: Du lieu tra ve -- 2: Ten phuong thuc --3: Tham so nhan vao paramater
        //entity: object: thuc the, doi tuong
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        T GetById(int id); 
    }
}
