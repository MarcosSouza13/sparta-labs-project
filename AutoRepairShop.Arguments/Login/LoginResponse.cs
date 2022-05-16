using AutoRepairShop.Arguments.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairShop.Arguments.Login
{
    public class LoginResponse : IResponse
    {
        public LoginResponse() { }

        public LoginResponse(Domain.Entities.Models.Login login)
        {
            Cnpj = login.Cnpj;
            Password = login.Password;
        }

        public string Cnpj { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
