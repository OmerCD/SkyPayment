namespace SkyPayment.Domain.CQ.Commands.AuthenticationCommands
{
    public class PersonnelUserRegisterCommand : IBaseRequest
    {
        public PersonnelUserRegisterCommand(string email, string name, string password, string lastName, string userName, string managementUserId, string restaurantId)
        {
            Email = email;
            Name = name;
            Password = password;
            LastName = lastName;
            UserName = userName;
            ManagementUserId = managementUserId;
            RestaurantId = restaurantId;
        }

        public PersonnelUserRegisterCommand()
        {
            
        }

        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string RestaurantId { get; set; }
        public string ManagementUserId { get; set; }
    }
}