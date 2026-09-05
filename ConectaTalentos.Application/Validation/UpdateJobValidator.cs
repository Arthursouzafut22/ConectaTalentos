using FluentValidation;
using ConectaTalentos.Application.DTOs.Jobs;

namespace ConectaTalentos.Domain.Validation
{
    public class UpdateJobValidator : AbstractValidator<UpdateJob>
    {
        public UpdateJobValidator()
        {
            RuleFor(x => x.Title)
               .MinimumLength(3).WithMessage("Título deve ter no mínimo 3 caracteres")
               .When(x => x.Title is not null);

            RuleFor(x => x.CompanyName)
               .MinimumLength(2).WithMessage("Nome da empresa deve ter no mínimo 2 caracteres")
               .When(x => x.CompanyName is not null);

            RuleFor(x => x.CompanyDescription)
               .MinimumLength(10).WithMessage("Descrição da empresa deve ter no mínimo 10 caracteres")
               .When(x => x.CompanyName is not null);

            RuleFor(x => x.DesiredTechnologies)
               .Must(t => t!.Length > 0).WithMessage("Informe ao menos uma tecnologia")
               .When(x => x.DesiredTechnologies is not null);

            RuleFor(x => x.Location)
               .MinimumLength(5).WithMessage("A localização da vaga deve ter no mínimo 5 caracteres")
               .When(x => x.DesiredTechnologies is not null);

            RuleFor(x => x.Salary)
                .GreaterThan(0).WithMessage("Salário deve ser maior que zero")
                .When(x => x.Salary is not null);

            RuleFor(x => x.ContractType)
                .IsInEnum().WithMessage("ipo de contrato inválido")
                .When(x => x.ContractType is not null);

            RuleFor(x => x.WorkMode)
                .IsInEnum().WithMessage("Modalidade de Trabalho inválido")
                .When(x => x.WorkMode is not null);

            RuleFor(x => x.Description)
                .MinimumLength(20).WithMessage("A Descrição da vaga deve ter no mínimo 20 caracteres")
                .When(x => x.WorkMode is not null);

            RuleFor(x => x.Benefits)
                .Must(b => b!.Count > 0).WithMessage("Informe ao menos um benefício")
                .When(x => x.Benefits is not null);

            RuleFor(x => x.Requirements)
               .Must(t => t!.Count > 0).WithMessage("Informe ao menos um beneficio")
               .When(x => x.Requirements is not null);

            RuleFor(x => x.IsActive)
                 .NotNull().WithMessage("Campo obrigatório")
                 .When(x => x.IsActive is not null);
        }
    }
}
