using AutoRepairShop.Domain.Base;

namespace AutoRepairShop.Domain.Entities.Models
{
    public class Login : Entity
    {
        public string Cnpj { get; set; }
        public string Password { get; set; }
    }
}
