using AutoRepairShop.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairShop.Domain.Entities.Models
{
    public class Login : Entity
    {
        public string Cnpj { get; set; }
        public string Password { get; set; }
    }
}
