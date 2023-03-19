using DiaDeFeira.API.Domain.Dtos;
using DiaDeFeira.API.Domain.Entities;

namespace DiaDeFeira.API.Services.Interfaces
{
    public interface IHistoricosService
    {
        Task CriaHistorico(Historico novoHistorico);
        Task RemoveHistorico(string idHistorico);
        Task AtualizaHistorico(string idHistorico, Historico historicoAtualizado);
        Task<Historico?> BuscaHistorico(string idHistorico);
        Task<List<Historico>> BuscaHistoricosPorIdUsuario(string idUsuario);
    }
}
