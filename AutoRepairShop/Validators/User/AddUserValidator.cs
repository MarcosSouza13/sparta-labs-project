using FluentValidation;

namespace AutoRepairShop.Api.Validators.User
{
    public class AddUserValidator : AbstractValidator<Domain.Entities.Models.User>
    {
        public AddUserValidator()
        {
            RuleFor(a => a.IdRepairShop)
                .NotEmpty().WithMessage("O Id da oficina não pode ser vazio ");
        }
    }
}
