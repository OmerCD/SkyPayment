namespace SkyPayment.Domain.CQ.Commands.AuthenticationCommands
{
    public class ClientUserRegisterCommand :IBaseRequest
    {
        public string Email { get; }
        public string Password { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string TelephoneNumber { get; }
        public string UserName { get;}

        public ClientUserRegisterCommand(string email, string password, string firstName, string lastName, string telephoneNumber, string userName)
        {
           Email = email.Trim().ToLower();
           Password = password;
           FirstName = firstName;
           LastName = lastName;
           TelephoneNumber = telephoneNumber;
           UserName = userName;
        }
    }
}