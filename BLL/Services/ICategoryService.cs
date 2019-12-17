using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DLL.Model;
using DLL.Repository;

namespace BLL.Services
{
    public interface ICategoryService
    {
        Task<Category> AddCategory(Category category);
        Task<List<Category>> GetAllCategory();
        Task<Category> DeleteCategory(long  categoryId);
        Task<Category> GetACategory(long id);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> AddCategory(Category category)
        {
            var result = await _categoryRepository.AddCategory(category);

            if (result)
            {
                return category;
            }
            
            throw new Exception("category not insert successfully");
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await _categoryRepository.GetAllCategory();
        }

        public async Task<Category> DeleteCategory(long  categoryId)
        {
            var result = await GetACategory(categoryId);

            var finalResult = await _categoryRepository.DeleteCategory(result);

            if (finalResult)
            {
                return result;
            }
            throw new Exception("delete not working");

        }

        public async Task<Category> GetACategory(long id)
        {
            var result = await _categoryRepository.GetACategory(id);

            if (result == null)
            {
                throw new Exception("category not found");
            }

            return result;
        }
    }
}