namespace SkyPayment.Domain.Queries
{
    public class GetAllMenuQueries:IBaseRequest
    {
        public GetAllMenuQueries(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}