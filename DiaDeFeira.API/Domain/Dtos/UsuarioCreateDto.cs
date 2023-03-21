namespace DiaDeFeira.API.Domain.Dtos
{
    public class UsuarioCreateDto
    {
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmaSenha { get; set; }
    }
}
