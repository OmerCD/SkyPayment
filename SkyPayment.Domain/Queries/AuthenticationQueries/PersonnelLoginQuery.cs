namespace SkyPayment.Domain.Queries.AuthenticationQueries
{
    public class PersonnelLoginQuery:IBaseRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }


        public PersonnelLoginQuery(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
    
}