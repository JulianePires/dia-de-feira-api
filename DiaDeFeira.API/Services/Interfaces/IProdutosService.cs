using DiaDeFeira.API.Domain.Dtos;
using DiaDeFeira.API.Domain.Entities;

namespace DiaDeFeira.API.Services.Interfaces
{
    public interface IProdutosService
    {
        Task CriaProduto(ProdutoRequestDto novoProduto);
        Task RemoveProduto(string idProduto);
        Task AtualizaProduto(string idProduto, ProdutoRequestDto produtoAtualizado);
        Task<Produto?> BuscaProduto(string idProduto);
        Task<Produto?> BuscaProdutoPorNome(string nomeProduto);
        Task AlteraCategoriaProduto(string idProduto, string idCategoria);
        Task<List<Produto>> BuscaTodosProdutos();
    }
}
