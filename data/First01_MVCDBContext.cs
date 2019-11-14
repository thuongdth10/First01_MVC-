using System;
using Model;
using Microsoft.EntityFrameworkCore;

namespace data
{
    public class First01_MVCDBContext : DbContext
    {
        public First01_MVCDBContext() : base((new DbContextOptionsBuilder())
            .UseLazyLoadingProxies()
            .UseSqlServer(@"Server=202.78.227.89;Database=Thuong;user id=sa;password=an@0906782333;Trusted_Connection=True;Integrated Security=false;")
            .Options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public void Comit()
        {
            base.SaveChanges();
        }
    }
}