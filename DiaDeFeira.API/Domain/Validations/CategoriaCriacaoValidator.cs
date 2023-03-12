using DiaDeFeira.API.Domain.Dtos;
using FluentValidation;

namespace DiaDeFeira.API.Domain.Validations
{
    public class CategoriaCriacaoValidator : AbstractValidator<CategoriaCriacaoDto>
    {
        public CategoriaCriacaoValidator()
        {
            RuleFor(x => x.NomeCategoria)
                .NotEmpty()
                .WithMessage("O nome da categoria é obrigatório!");
        }
    }
}
