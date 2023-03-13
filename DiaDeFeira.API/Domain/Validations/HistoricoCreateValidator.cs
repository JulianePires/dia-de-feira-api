using DiaDeFeira.API.Domain.Dtos;
using FluentValidation;

namespace DiaDeFeira.API.Domain.Validations
{
    public class HistoricoCreateValidator : AbstractValidator<HistoricoCreateDto>
    {
        public HistoricoCreateValidator()
        {
            RuleFor(x => x.IdUsuario)
                .NotEmpty()
                .WithMessage("Id do Usuário é obrigatório!");
        }
    }
}
