namespace SkyPayment.Domain.CQ.Queries.AuthenticationQueries
{
    public class CustomerLoginQuery: IBaseRequest

    {
        public string UserName { get; }
        public string Password { get; }

        public CustomerLoginQuery(string userName, string password)
        {
            UserName = userName.Trim().ToLower();
            Password = password;
        }
    }
}