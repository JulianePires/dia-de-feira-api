using DiaDeFeira.API.Infraestructure.Repositories.Base;
using DiaDeFeira.API.Services;
using DiaDeFeira.API.Services.Interfaces;

namespace DiaDeFeira.API.Infraestructure.Configurations
{
    public static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            service.AddSingleton<DBContext>()
                .AddScoped<ICategoriasService, CategoriasService>()
                .AddScoped<IProdutosService, ProdutosService>()
                .AddScoped<IListasService, ListasService>()
                .AddScoped<IUsuariosService, UsuariosService>()
                .AddScoped<IHistoricosService, HistoricosService>();

            service.AddSingleton<CategoriasService>();
            service.AddSingleton<ProdutosService>();
            service.AddSingleton<ListasService>();
            service.AddSingleton<UsuariosService>();
            service.AddSingleton<HistoricosService>();

            return service;
        }

    }
}
