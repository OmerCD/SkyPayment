using MediatR;

namespace SkyPayment.Domain.Commands.RestaurantCommand
{
    public class RestaurantUpdateCommand:IRequest<bool>
    {
        
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        //   public ICollection<MenuResponseModel> Menus { get; set;}=new List<MenuResponseModel>();
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string ManagementUserId { get; set; }
        public int TableCount { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }

        public RestaurantUpdateCommand(string userId, string name, string address, string phoneNumber, string faxNumber, string email, string website, string managementUserId, int tableCount, string link, bool isActive)
        {
            UserId = userId;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            FaxNumber = faxNumber;
            Email = email;
            Website = website;
            ManagementUserId = managementUserId;
            TableCount = tableCount;
            Link = link;
            IsActive = isActive;
        }
    }
}