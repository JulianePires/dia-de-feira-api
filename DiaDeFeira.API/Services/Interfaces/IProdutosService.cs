using DiaDeFeira.API.Domain.Dtos;
using DiaDeFeira.API.Domain.Entities;

namespace DiaDeFeira.API.Services.Interfaces
{
    public interface IProdutosService
    {
        Task CriaProduto(Produto novoProduto);
        Task RemoveProduto(string idProduto);
        Task AtualizaProduto(string idProduto, Produto produtoAtualizado);
        Task<Produto?> BuscaProduto(string idProduto);
        Task<Produto?> BuscaProdutoPorNome(string nomeProduto);
        Task<List<Produto>> BuscaTodosProdutos();
    }
}
