using DiaDeFeira.API.Infraestructure.Repositories.Base;
using DiaDeFeira.API.Services;
using DiaDeFeira.API.Services.Interfaces;

namespace DiaDeFeira.API.Infraestructure.Configurations
{
    public static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            service.AddSingleton<DBContext>().AddScoped<ICategoriasService, CategoriasService>();
            service.AddSingleton<CategoriasService>();

            return service;
        }
     
    }
}
