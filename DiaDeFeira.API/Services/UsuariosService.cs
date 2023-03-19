using DiaDeFeira.API.Domain.Dtos;
using DiaDeFeira.API.Domain.Entities;
using DiaDeFeira.API.Helpers;
using DiaDeFeira.API.Infraestructure.Repositories.Base;
using DiaDeFeira.API.Services.Interfaces;
using MongoDB.Driver;

namespace DiaDeFeira.API.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly DBContext _dbContext;

        public UsuariosService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CriaUsuario(Usuario novoUsuario)
        {
            await _dbContext.Usuarios.InsertOneAsync(novoUsuario);
        }

        public async Task RemoveUsuario(string idUsuario)
        {
            await _dbContext.Usuarios
                .DeleteOneAsync(RepositoryHelper.FiltraPorId<Usuario>(idUsuario));
        }

        public async Task AtualizaUsuario(string idUsuario, Usuario usuarioEditado)
        {
            await _dbContext.Usuarios
                .ReplaceOneAsync(RepositoryHelper.FiltraPorId<Usuario>(idUsuario), usuarioEditado);
        }

        public async Task<Usuario?> BuscaUsuario(string idUsuario)
        {
            return await _dbContext.Usuarios
               .Find(RepositoryHelper.FiltraPorId<Usuario>(idUsuario))
               .FirstOrDefaultAsync();
        }

        public async Task<Usuario?> LoginUsuario(UsuarioLoginDto usuario)
        {
            return await _dbContext.Usuarios
               .Find((Builders<Usuario>.Filter.Eq(x => x.Email, usuario.Email)))
               .FirstOrDefaultAsync();
        }

        public async Task<List<Usuario>> BuscaTodosUsuarios()
        {
            return await _dbContext.Usuarios.Find(_ => true).ToListAsync();
        }
    }
}
