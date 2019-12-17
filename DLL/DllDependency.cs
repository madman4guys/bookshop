using DLL.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DLL
{
    public class DllDependency
    {
        public static void LoadDependency(IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
        }
    }
}