using DiaDeFeira.API.Domain.Dtos;
using FluentValidation;

namespace DiaDeFeira.API.Domain.Validations
{
    public class UsuarioEditValidator : AbstractValidator<UsuarioEditDto>
    {
        public UsuarioEditValidator()
        {
            RuleFor(x => x.NomeUsuario)
                .NotEmpty()
                .WithMessage("Nome de usuário é obrigatório!");
        }
    }
}
