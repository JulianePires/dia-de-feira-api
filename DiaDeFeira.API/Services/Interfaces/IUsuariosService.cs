using DiaDeFeira.API.Domain.Dtos;
using DiaDeFeira.API.Domain.Entities;

namespace DiaDeFeira.API.Services.Interfaces
{
    public interface IUsuariosService
    {
        Task CriaUsuario(Usuario novoUsuario);
        Task RemoveUsuario(string idUsuario);
        Task AtualizaUsuario(string idUsuario, Usuario usuarioEditado);
        Task<Usuario?> BuscaUsuario(string idUsuario);
        Task<Usuario?> LoginUsuario(UsuarioLoginDto usuario);
        Task<List<Usuario>> BuscaTodosUsuarios();
    }
}
