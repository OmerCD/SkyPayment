namespace SkyPayment.Domain.CQ.Queries.RestaurantQueries
{
    public class GetAllRestaurantForDisplayQuery : IBaseRequest
    {
        public string ManagementUserId { get; }

        public GetAllRestaurantForDisplayQuery(string managementUserId)
        {
            ManagementUserId = managementUserId;
        }
    }
}