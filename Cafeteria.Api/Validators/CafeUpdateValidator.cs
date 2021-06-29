using Cafeteria.Api.Domain.Models.Request;
using FluentValidation;

namespace Cafeteria.Api.Validators
{
    public class CafeUpdateValidator : AbstractValidator<CafeUpdateRequest>
    {
        public CafeUpdateValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;//da consistência em sequência


            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Informe o nome")
                .MinimumLength(10).WithMessage("O nome deve ter no mínimo 10 caracteres")
                .MaximumLength(150).WithMessage("O nome deve ter no máximo 150 caracteres")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Tipo)
                    .NotEmpty().WithMessage("Informe o nome")
                    .MinimumLength(10).WithMessage("O nome deve ter no mínimo 10 caracteres")
                    .MaximumLength(150).WithMessage("O nome deve ter no máximo 150 caracteres")
                    .DependentRules(() =>
                    {
                           RuleFor(x => x.Preco)
                               .GreaterThan(0).WithMessage("Informe o Preço.")
                               .LessThanOrEqualTo(100).WithMessage("A Café informado não existe.");
                        });
                });
        }
    }
}
