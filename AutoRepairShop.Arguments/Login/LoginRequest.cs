using AutoRepairShop.Arguments.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
