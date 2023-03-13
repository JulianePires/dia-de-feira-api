using DiaDeFeira.API.Domain.Dtos;
using FluentValidation;

namespace DiaDeFeira.API.Domain.Validations
{
    public class ItemEditValidator : AbstractValidator<ItemEditDto>
    {
        public ItemEditValidator()
        {
            RuleFor(x => x.Preco)
                .GreaterThanOrEqualTo(0)
                .WithMessage("O Preço deve ser maior ou igual a 0");

            RuleFor(x => x.Quantidade)
                .GreaterThanOrEqualTo(0)
                .WithMessage("A Quantidade deve ser maior ou igual a 0");
        }
    }
}
