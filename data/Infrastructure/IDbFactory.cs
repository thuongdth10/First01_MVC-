using System;
namespace data.Infrastructure
{
   public interface IDbFactory : IDisposable {
        First01_MVCDBContext Init();
    }
}
