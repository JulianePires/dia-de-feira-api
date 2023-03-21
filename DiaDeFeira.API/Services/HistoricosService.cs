using DiaDeFeira.API.Domain.Entities;
using DiaDeFeira.API.Helpers;
using DiaDeFeira.API.Infraestructure.Repositories.Base;
using DiaDeFeira.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace DiaDeFeira.API.Services
{
    public class HistoricosService : IHistoricosService
    {
        private readonly DBContext _dbContext;

        public HistoricosService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CriaHistorico(Historico novoHistorico)
        {
            await _dbContext.Historicos.InsertOneAsync(novoHistorico);
        }

        public async Task RemoveHistorico(string idHistorico)
        {
            await _dbContext.Historicos
                 .DeleteOneAsync(RepositoryHelper.FiltraPorId<Historico>(idHistorico));
        }

        public async Task AtualizaHistorico(string idHistorico, Historico historicoAtualizado)
        {
            await _dbContext.Historicos
                .ReplaceOneAsync(RepositoryHelper.FiltraPorId<Historico>(idHistorico), historicoAtualizado);
        }

        public async Task<Historico?> BuscaHistorico(string idHistorico)
        {
            return await _dbContext.Historicos
                .Find(RepositoryHelper.FiltraPorId<Historico>(idHistorico))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Historico>> BuscaHistoricosPorIdUsuario(string idUsuario)
        {
            return await _dbContext.Historicos.Find(_ => true).ToListAsync();
        }
    }
}
