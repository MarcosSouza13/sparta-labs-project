using FluentValidation;

namespace AutoRepairShop.Api.Validators.Maintenance
{
    public class AddMaintenanceValidator : AbstractValidator<Domain.Entities.Models.Maintenance>
    {
        public AddMaintenanceValidator()
        {
            RuleFor(a => a.IdRepairShop)
                .NotEmpty().WithMessage("O Id da oficina não pode ser vazio ");

            RuleFor(a => a.Name)
                .NotEmpty().WithMessage("É necessário possuir um nome para o serviço")
                .Length(1, 128).WithMessage("O nome do serviço não pode possuir mais de 128 caracteres");

            RuleFor(a => a.ClientName)
                .NotEmpty().WithMessage("É necessário possuir o nome do cliente")
                .Length(1, 128).WithMessage("O nome do cliente não pode possuir mais de 128 caracteres");

            RuleFor(a => a.Type)
                .IsInEnum().WithMessage("Tipo não serviço não existe")
                .NotNull().WithMessage("É necessário possuir o tipo de serviço");

            RuleFor(a => a.ScheduledAt)
                .NotEmpty().WithMessage("É necessário possuir a data do serviço");

        }
    }
}
