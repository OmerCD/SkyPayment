namespace SkyPayment.Contract.RequestModel.Authentication
{
    public class UserRegisterCreateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
    }
}