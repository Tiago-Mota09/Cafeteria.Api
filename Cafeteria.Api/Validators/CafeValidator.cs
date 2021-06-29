using Cafeteria.Api.Domain.Models.Request;
using FluentValidation;

namespace Cafeteria.Api.Validators
{
    public class CafeValidator : AbstractValidator<CafeRequest>
    {
        public CafeValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;//da consistência em sequência
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Informe o nome do Café")
                .MinimumLength(5).WithMessage("O nome do Café deve ter no mínimo 5 caracteres")
                .MaximumLength(150).WithMessage("O nome do Café ter no máximo 150 caracteres")
                .DependentRules(() =>
               {
                   RuleFor(x => x.Preco)
                               .GreaterThan(0).WithMessage("Informe o Preço.")
                               .LessThanOrEqualTo(100).WithMessage("O nome do Café informado não existe.");
               });
        }
        
    }
}
