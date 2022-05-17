using FluentValidation;

namespace AutoRepairShop.Api.Validators.User
{
    public class AddUserValidator : AbstractValidator<Domain.Entities.Models.User>
    {
        public AddUserValidator()
        {
            RuleFor(a => a.IdRepairShop)
                .NotEmpty().WithMessage("O Id da oficina não pode ser vazio ");

            RuleFor(a => a.Name)
            .NotEmpty().WithMessage("É necessário possuir um nome para o usuário")
            .Length(1, 128).WithMessage("O nome do serviço não pode possuir mais de 128 caracteres");

            RuleFor(a => a.Password)
                .NotEmpty().WithMessage("É necessário possuir a senha do usuário")
                .Length(1, 128).WithMessage("A senha do usuário não pode possuir mais de 250 caracteres");

        }
    }
}
