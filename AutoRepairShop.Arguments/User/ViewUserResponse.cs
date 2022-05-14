using AutoRepairShop.Arguments.Base;

namespace AutoRepairShop.Arguments.User
{
    public class ViewUserResponse : IResponse
    {
        public ViewUserResponse() { }

        public ViewUserResponse(Domain.Entities.Models.User user)
        {
            Id = user.Id;
            Cnpj = user.Cnpj;
            Name = user.Name;
            Password = user.Password;
        }

        public long Id { get; set; }
        public string Cnpj { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
