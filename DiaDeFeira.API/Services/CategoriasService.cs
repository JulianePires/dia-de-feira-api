using DiaDeFeira.API.Domain.Entities;
using DiaDeFeira.API.Helpers;
using DiaDeFeira.API.Infraestructure.Repositories.Base;
using DiaDeFeira.API.Services.Interfaces;
using MongoDB.Driver;

namespace DiaDeFeira.API.Services
{
    public class CategoriasService : ICategoriasService
    {
        private readonly DBContext _dbContext;

        public CategoriasService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CriaCategoria(Categoria novaCategoria)
        {
            await _dbContext.Categorias.InsertOneAsync(novaCategoria);
        }

        public async Task RemoveCategoria(string idCategoria)
        {
            await _dbContext.Categorias
                .DeleteOneAsync(RepositoryHelper.FiltraPorId<Categoria>(idCategoria));
        }

        public async Task AtualizaCategoria(string idCategoria, Categoria categoriaAtualizada)
        {
            await _dbContext.Categorias
                .ReplaceOneAsync(RepositoryHelper.FiltraPorId<Categoria>(idCategoria), categoriaAtualizada);
        }

        public async Task<Categoria?> BuscaCategoria(string idCategoria)
        {
            return await _dbContext.Categorias
                .Find(RepositoryHelper.FiltraPorId<Categoria>(idCategoria))
                .FirstOrDefaultAsync();
        }

        public async Task<Categoria?> BuscaCategoriaPorNome(string nomeCategoria)
        {
            return await _dbContext.Categorias.Find(Builders<Categoria>.Filter.Eq<string>(x => x.NomeCategoria, nomeCategoria))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Categoria>> BuscaTodasCategorias()
        {
            return await _dbContext.Categorias.Find(_ => true).ToListAsync();
        }
    }
}
