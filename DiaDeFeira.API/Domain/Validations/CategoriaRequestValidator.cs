using DiaDeFeira.API.Domain.Dtos;
using FluentValidation;

namespace DiaDeFeira.API.Domain.Validations
{
    public class CategoriaRequestValidator : AbstractValidator<CategoriaRequestDto>
    {
        public CategoriaRequestValidator()
        {
            RuleFor(x => x.NomeCategoria)
                .NotEmpty()
                .WithMessage("O nome da categoria é obrigatório!");
        }
    }
}
