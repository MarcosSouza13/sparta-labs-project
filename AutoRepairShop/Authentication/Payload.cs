using System;

namespace AutoRepairShop.Api.Authentication
{
    public class Payload
    {
        public string CompanyId { get; set; }
        public UserPayload User { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }

    public class UserPayload {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
