using BLL.Request;
using BLL.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public class BllDependency
    {
        public static void LoadDependency(IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();

            ForAllTypeOfFluentValidation(services);
        }

        private static void ForAllTypeOfFluentValidation(IServiceCollection services)
        {
            services.AddTransient<IValidator<CategoryInsertViewModel>, CategoryInsertViewModelValidator>();
           
        }
    }
}