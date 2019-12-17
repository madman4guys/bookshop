using System.Threading;
using System.Threading.Tasks;
using BLL.Services;
using FluentValidation;

namespace BLL.Request
{
    public class CategoryInsertViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CategoryInsertViewModelValidator : AbstractValidator<CategoryInsertViewModel>
    {
        private readonly ICategoryService _categoryService;

        public CategoryInsertViewModelValidator(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            RuleFor(x => x.Name).NotEmpty().WithMessage("please enter name").MinimumLength(4).MustAsync(NameExits).WithMessage("category name already exists");
        }

        private async Task<bool> NameExits(string name, CancellationToken arg2)
        {
            if(string.IsNullOrEmpty(name))
            {
                return true;
            }

            return !  await _categoryService.NameExits(name);
        }
    }
}