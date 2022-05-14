using AutoRepairShop.Arguments.Base;

namespace AutoRepairShop.Arguments.User
{
    public class AddUserRequest : IRequest
    {
        public AddUserRequest(Domain.Entities.Models.User user)
        {
            Id = user.Id;
            Cnpj = user.Cnpj;
            Name = user.Name;
            Password = user.Password;
        }

        public Domain.Entities.Models.User ToUser()
        {
            return new Domain.Entities.Models.User
            {
                Id = Id,
                Cnpj = Cnpj,
                Name = Name,
                Password = Password,
            };
        }

        public long Id { get; set; }
        public string Cnpj { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
