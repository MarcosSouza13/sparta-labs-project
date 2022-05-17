using FluentValidation;

namespace AutoRepairShop.Api.Validators.RepairShopConfiguration
{
    public class AddRepairShopConfigurationValidator : AbstractValidator<Domain.Entities.Models.RepairShopConfiguration>
    {
        public AddRepairShopConfigurationValidator()
        {
            RuleFor(a => a.IdRepairShop)
                .NotEmpty().WithMessage("O Id da oficina não pode ser vazio ");

            RuleFor(a => a.WorkBalance)
                .NotEmpty().WithMessage("A carga de trabalho da oficina não pode ser vazia");
        }
    }
}
