using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLL.Context;
using DLL.Model;
using Microsoft.EntityFrameworkCore;

namespace DLL.Repository
{
    public interface ICategoryRepository
    {
        Task<bool> AddCategory(Category category);
        Task<List<Category>> GetAllCategory();
        Task<bool> DeleteCategory(Category category);
        Task<Category> GetACategory(long id);
        Task<Category> NameExits(string name);
    }

    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCategory(Category category)
        {
           await _context.Categories.AddAsync(category);
           return await _context.SaveChangesAsync() > 0;

        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<bool> DeleteCategory(Category category)
        {
             _context.Categories.Remove(category);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Category> GetACategory(long id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
        }

        public async Task<Category> NameExits(string name)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}