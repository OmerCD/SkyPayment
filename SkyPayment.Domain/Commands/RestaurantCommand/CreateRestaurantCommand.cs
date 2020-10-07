using MediatR;
using SkyPayment.Contract.ResponseModel;
using SkyPayment.Core.Entities;

namespace SkyPayment.Domain.Command
{
    public class CreateRestaurantCommand:IBaseRequest
    {

        public string Name { get; set; }
        public string Address { get; set; }
        //public ICollection<Menu> Menus { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        //  public ICollection<MenuItemTag> AvailableTags { get; set; }
        public string ManagementUserId { get; set; }
        public int TableCount { get; set; }
        public string Link { get; set; }

        public CreateRestaurantCommand(string name, string address, string phoneNumber, string faxNumber, string email, string website, string managementUserId, int tableCount, string link)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            FaxNumber = faxNumber;
            Email = email;
            Website = website;
            ManagementUserId = managementUserId;
            TableCount = tableCount;
            Link = link;
        }
    }
    
}