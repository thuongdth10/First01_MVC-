using System;
using data.Infrastructure;
using Model;

namespace data.Repositories
{
    public  interface ICategoryRepository : IRepository<Category>
    {
       
    }
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }

}



