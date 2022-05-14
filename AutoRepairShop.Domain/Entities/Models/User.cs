using AutoRepairShop.Domain.Base;

namespace AutoRepairShop.Domain.Entities.Models
{
    public class User : Entity
    {
        public long Id { get; set; }
        public string Cnpj { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
