namespace SkyPayment.Domain.CQ.Queries.MenuQueries
{
    public class GetRestaurantMenuQuery : IBaseRequest
    {
        public string ManagementUserId { get; }
        public string RestaurantId { get; }

        public GetRestaurantMenuQuery(string managementUserId, string restaurantId)
        {
            ManagementUserId = managementUserId;
            RestaurantId = restaurantId;
        }
    }
}