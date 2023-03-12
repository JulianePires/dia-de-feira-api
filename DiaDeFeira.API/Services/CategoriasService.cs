using DiaDeFeira.API.Domain.Entities;
using DiaDeFeira.API.Infraestructure.Repositories.Base;
using DiaDeFeira.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        private FilterDefinition<Categoria> FiltraPorId(string idCategoria) =>
            Builders<Categoria>.Filter.Eq<string>(x => x.Id, idCategoria);

        public async Task CriaCategoria(Categoria novaCategoria)
        {
            await _dbContext.Categorias.InsertOneAsync(novaCategoria);
        }


        public async Task RemoveCategoria(string idCategoria)
        {
            await _dbContext.Categorias.DeleteOneAsync(FiltraPorId(idCategoria));
        }


        public async Task AtualizaCategoria(string categoriaId, Categoria categoriaAtualizada)
        {
             await _dbContext.Categorias.ReplaceOneAsync(FiltraPorId(categoriaId), categoriaAtualizada);
        }

        public async Task<Categoria?> BuscaCategoria(string idCategoria)
        {
            return await _dbContext.Categorias.Find(FiltraPorId(idCategoria)).FirstOrDefaultAsync();
        }

        public async Task<Categoria?> BuscaCategoriaPorNome(string nomeCategoria)
        {
            return await _dbContext.Categorias.Find(Builders<Categoria>.Filter.Eq<string>(x => x.NomeCategoria, nomeCategoria)).FirstOrDefaultAsync();
        }

        public async Task<List<Categoria>> BuscaTodasCategorias()
        {
            return await _dbContext.Categorias.Find(_ => true).ToListAsync();
        }
    }
}
