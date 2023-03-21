using DiaDeFeira.API.Domain.Dtos;
using FluentValidation;

namespace DiaDeFeira.API.Domain.Validations
{
    public class ProdutoRequestValidator : AbstractValidator<ProdutoRequestDto>
    {
        public ProdutoRequestValidator()
        {
            RuleFor(x => x.NomeProduto)
                .NotEmpty()
                .WithMessage("Nome do produto é obrigatório");
        }
    }
}
