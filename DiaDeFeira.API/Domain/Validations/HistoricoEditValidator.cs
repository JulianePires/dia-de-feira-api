using DiaDeFeira.API.Domain.Dtos;
using FluentValidation;

namespace DiaDeFeira.API.Domain.Validations
{
    public class HistoricoEditValidator : AbstractValidator<HistoricoEditDto>
    {
        public HistoricoEditValidator()
        {
            RuleForEach(x => x.ListasId)
                .NotEmpty()
                .WithMessage("Id das Listas devem ser válidos!");
        }
    }
}
