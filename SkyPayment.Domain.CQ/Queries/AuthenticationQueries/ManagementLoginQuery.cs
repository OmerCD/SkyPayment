namespace SkyPayment.Domain.CQ.Queries.AuthenticationQueries
{
    public class ManagementLoginQuery : IBaseRequest
    {
        public string Password { get; set; }
        public string UserName { get; set; }

        public ManagementLoginQuery(string password, string userName)
        {
            Password = password;
            UserName = userName;
        }
    }
}