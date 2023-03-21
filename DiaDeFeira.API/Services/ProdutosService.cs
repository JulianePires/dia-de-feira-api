using DiaDeFeira.API.Domain.Dtos;
using DiaDeFeira.API.Domain.Entities;
using DiaDeFeira.API.Helpers;
using DiaDeFeira.API.Infraestructure.Repositories.Base;
using DiaDeFeira.API.Services.Interfaces;
using MongoDB.Driver;

namespace DiaDeFeira.API.Services
{
    public class ProdutosService : IProdutosService
    {
        private readonly DBContext _dbContext;

        public ProdutosService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CriaProduto(Produto novoProduto)
        {
            await _dbContext.Produtos.InsertOneAsync(novoProduto);
        }

        public async Task RemoveProduto(string idProduto)
        {
            await _dbContext.Produtos
                .DeleteOneAsync(RepositoryHelper
                .FiltraPorId<Produto>(idProduto));
        }

        public async Task AtualizaProduto(string idProduto, Produto produtoAtualizado)
        {
            await _dbContext.Produtos
                .ReplaceOneAsync(RepositoryHelper.FiltraPorId<Produto>(idProduto), produtoAtualizado);
        }

        public async Task<Produto?> BuscaProduto(string idProduto)
        {
            return await _dbContext.Produtos
                .Find(RepositoryHelper.FiltraPorId<Produto>(idProduto))
                .FirstOrDefaultAsync();
        }

        public async Task<Produto?> BuscaProdutoPorNome(string nomeProduto)
        {
            return await _dbContext.Produtos
                .Find(Builders<Produto>.Filter.Eq<string>(x => x.NomeProduto, nomeProduto))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Produto>> BuscaTodosProdutos()
        {
            return await _dbContext.Produtos.Find(_ => true).ToListAsync();
        }
    }
}
