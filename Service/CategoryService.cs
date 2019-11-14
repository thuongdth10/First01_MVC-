using System;
using System.Linq;
using data.Infrastructure;
using data.Repositories;
using Model;

namespace Service
{
   
        public interface ICategoryService
        {
            IQueryable<Category> GetCategories();
            void AddCategory(Category category);
            void UpdateCategory(Category category);
            void DeleteCategory(Category category);
            Category GetById(int id);
            void SaveChange();
        }
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AddCategory(Category category)
        {
            categoryRepository.Add(category);
        }

        public void DeleteCategory(Category category)
        {
            categoryRepository.Delete(category);
        }

        public Category GetById(int id)
        {
            return categoryRepository.GetById(id);
        }

        public IQueryable<Category> GetCategories()
        {
            return categoryRepository.GetAll();
        }

        public void SaveChange()
        {
            unitOfWork.Comit();
        }

        public void UpdateCategory(Category category)
        {
            categoryRepository.Update(category);
        }
    }

}
