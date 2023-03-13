using DiaDeFeira.API.Domain.Dtos;
using FluentValidation;

namespace DiaDeFeira.API.Domain.Validations
{
    public class UsuarioLoginValidator : AbstractValidator<UsuarioLoginDto>
    {
        public UsuarioLoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email é obrigatório!");

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage("Senha é obrigatória!");
        }
    }
}
