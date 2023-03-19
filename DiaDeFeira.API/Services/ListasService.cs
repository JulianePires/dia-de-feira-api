using DiaDeFeira.API.Domain.Entities;
using DiaDeFeira.API.Helpers;
using DiaDeFeira.API.Infraestructure.Repositories.Base;
using DiaDeFeira.API.Services.Interfaces;
using MongoDB.Driver;

namespace DiaDeFeira.API.Services
{
    public class ListasService : IListasService
    {
        private readonly DBContext _dbContext;

        public ListasService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CriaLista(Lista novaLista)
        {
            await _dbContext.Listas.InsertOneAsync(novaLista);
        }

        public async Task RemoveLista(string idLista)
        {
            await _dbContext.Listas
                 .DeleteOneAsync(RepositoryHelper.FiltraPorId<Lista>(idLista));
        }

        public async Task AtualizaLista(string idLista, Lista listaAtualizada)
        {
            await _dbContext.Listas
                .ReplaceOneAsync(RepositoryHelper.FiltraPorId<Lista>(idLista), listaAtualizada);
        }

        public async Task<Lista?> BuscaLista(string idLista)
        {
            return await _dbContext.Listas
                .Find(RepositoryHelper.FiltraPorId<Lista>(idLista))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Lista>> BuscaTodasListas()
        {
            return await _dbContext.Listas.Find(_ => true).ToListAsync();
        }
    }
}
