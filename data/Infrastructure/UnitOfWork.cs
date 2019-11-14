using System;
namespace data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private First01_MVCDBContext dbContext;
        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public First01_MVCDBContext DbContext
        {
            get
            {
                if(dbContext == null)
                {
                    dbContext = dbFactory.Init();
                }
                return dbContext;
            }
        }

        public void Comit()
        {
            DbContext.Comit();
        }
    }
}
