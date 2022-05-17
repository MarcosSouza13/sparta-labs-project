using AutoRepairShop.Arguments.Base;

namespace AutoRepairShop.Arguments.Login
{
    public class LoginRequest : IRequest
    {
        public LoginRequest() { }

        public LoginRequest(Domain.Entities.Models.Login login)
        {
            Cnpj = login.Cnpj;
            Password = login.Password;
        }

        public Domain.Entities.Models.Login ToLogin()
        {
            return new Domain.Entities.Models.Login
            {
                Cnpj = Cnpj,
                Password = Password
            };
        }

        public string Cnpj { get; set; }
        public string Password { get; set; }
    }
}
