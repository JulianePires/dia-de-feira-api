using DiaDeFeira.API.Domain.Dtos;
using FluentValidation;

namespace DiaDeFeira.API.Domain.Validations
{
    public class ListaCreateValidator : AbstractValidator<ListaCreateDto>
    {
        public ListaCreateValidator()
        {
            RuleFor(x => x.NomeLista)
                .NotEmpty()
                .WithMessage("Nome da lista é origatório!");
        }
    }
}
