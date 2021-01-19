using Clara.Repository;
using Clara.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Clara.Extension_Methods
{
    public static class ServiceExtension
    {
        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}
