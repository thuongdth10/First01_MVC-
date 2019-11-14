using System;
namespace data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        //class de khoi tao DBContext
        //DBcontext giao tiep voi DB
        private First01_MVCDBContext dbContext;

        public First01_MVCDBContext Init()
        {
            if(dbContext == null)
            {
                dbContext = new First01_MVCDBContext();
               
            }
            return dbContext;
        }

        protected override void DisposeCore()
        {
            if(dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}
