using System.Threading.Tasks;
using BLL.Services;
using DLL.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAllCategory());
        }
        
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> Get(long categoryId)
        {
            return Ok(await _categoryService.GetACategory(categoryId));
        }
        
        [HttpPost]
        public async Task<IActionResult> Insert(Category category)
        {
            return Ok(await _categoryService.AddCategory(category));
        }
        
        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> Delete(long categoryId)
        {
            return Ok(await _categoryService.DeleteCategory(categoryId));
        }
        
        
        
        
    }
}