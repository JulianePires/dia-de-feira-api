using DiaDeFeira.API.Domain.Dtos;
using DiaDeFeira.API.Domain.Entities;

namespace DiaDeFeira.API.Services.Interfaces
{
    public interface IListasService
    {
        Task CriaLista(Lista novaLista);
        Task RemoveLista(string idLista);
        Task AtualizaLista(string idLista, Lista listaAtualizada);
        Task<Lista?> BuscaLista(string idLista);
        Task<List<Lista>> BuscaTodasListas();
    }
}
