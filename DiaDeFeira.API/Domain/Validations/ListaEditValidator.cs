using DiaDeFeira.API.Domain.Dtos;
using FluentValidation;

namespace DiaDeFeira.API.Domain.Validations
{
    public class ListaEditValidator : AbstractValidator<ListaEditDto>
    {
        public ListaEditValidator()
        {
            RuleForEach(x => x.ItensId)
                .NotEmpty()
                .WithMessage("Id dos Itens devem ser válidos!");
        }
    }
}
