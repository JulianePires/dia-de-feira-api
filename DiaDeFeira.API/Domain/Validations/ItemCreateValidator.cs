using DiaDeFeira.API.Domain.Dtos;
using FluentValidation;

namespace DiaDeFeira.API.Domain.Validations
{
    public class ItemCreateValidator : AbstractValidator<ItemCreateDto>
    {
        public ItemCreateValidator()
        {
            RuleFor(x => x.IdProduto)
                .NotEmpty()
                .WithMessage("O Id do Produto é obrigatório!");
        }
    }
}
