using AutoRepairShop.Arguments.Base;

namespace AutoRepairShop.Arguments.User
{
    public class EditUserRequest : IRequest
    {
        public EditUserRequest() { }

        public EditUserRequest(Domain.Entities.Models.User user)
        {
            Id = user.Id;
            Name = user.Name;
        }

        public Domain.Entities.Models.User ToUser()
        {
            return new Domain.Entities.Models.User
            {
                Id = Id,
                Name = Name,
            };
        }

        public long Id { get; set; }
        public string Name { get; set; }
    }
}
