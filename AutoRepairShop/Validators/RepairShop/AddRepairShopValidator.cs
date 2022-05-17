using FluentValidation;

namespace AutoRepairShop.Api.Validators.RepairShop
{
    public class AddRepairShopValidator : AbstractValidator<Domain.Entities.Models.RepairShop>
    {
        public AddRepairShopValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty().WithMessage("O nome da oficina não pode ser vazio.");
            RuleFor(a => a.Cnpj)
                .NotEmpty().WithMessage("O nome da oficina não pode ser vazio.")
                .MaximumLength(14).WithMessage("O CNPJ da oficina está inválido");
        }
    }
}
