using DiaDeFeira.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DiaDeFeira.API.Services.Interfaces
{
    public interface ICategoriasService
    {
        Task CriaCategoria(Categoria novaCategoria);
        Task RemoveCategoria(string idCategoria);
        Task AtualizaCategoria(string idCategoria, Categoria categoriaAtualizada);
        Task<Categoria?> BuscaCategoria(string idCategoria);
        Task<Categoria?> BuscaCategoriaPorNome(string nomeCategoria);
        Task<List<Categoria>> BuscaTodasCategorias();
    }
}
