namespace SkyPayment.Domain.Commands.AuthenticationCommands
{
    public class ManagementUserRegisterCommand : IBaseRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public ManagementUserRegisterCommand(string email, string name, string password, string lastName, string userName)
        {
            Email = email;
            Name = name;
            Password = password;
            LastName = lastName;
            UserName = userName;
        }
    }
}