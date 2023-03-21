using DiaDeFeira.API.Domain.Dtos;
using FluentValidation;

namespace DiaDeFeira.API.Domain.Validations
{
    public class UsuarioCreateValidation : AbstractValidator<UsuarioCreateDto>
    {
        public UsuarioCreateValidation()
        {
            RuleFor(x => x.NomeUsuario)
                .NotEmpty()
                .WithMessage("Nome do Usuário é obrigatório!");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email é obrigatório!");

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage("Senha é obrigatória!");

            RuleFor(x => x.ConfirmaSenha)
                .NotEmpty()
                .WithMessage("Senha de confirmação é obrigatória!")
                .Equal(x => x.Senha)
                .WithMessage("As senhas devem ser iguais!");
        }
    }
}
