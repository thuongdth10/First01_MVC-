using System;
using System.Linq;
using data.Infrastructure;
using data.Repositories;
using Model;

namespace Service
{
    public interface IProductService
    {
        IQueryable<Product> GetProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        Product GetById(int id);
        void SaveChange();
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddProduct(Product product)
        {
            productRepository.Add(product);
        }

        public IQueryable<Product> GetProducts()
        {
            return productRepository.GetAll();
        }
        public void UpdateProduct(Product product)
        {
            productRepository.Update(product);
        }
        public void DeleteProduct(Product product)
        {
            productRepository.Delete(product);
        }
        public Product GetById(int id)
        {
            return productRepository.GetById(id);
        }
        public void SaveChange()
        {
            unitOfWork.Comit();
        }

       
    }
}
