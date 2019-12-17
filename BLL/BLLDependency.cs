using BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public class BllDependency
    {
        public static void LoadDependency(IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();
        }
    }
}