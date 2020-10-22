namespace SkyPayment.Contract.RequestModel.Authentication
{
    public class PersonnelRegisterCreateModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RestaurantId { get; set; }
        public string UserName { get; set; }
    }
}