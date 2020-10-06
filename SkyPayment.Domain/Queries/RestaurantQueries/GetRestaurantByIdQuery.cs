using System.Security.Claims;

namespace SkyPayment.Domain.Queries.RestaurantQueries
{
    public class GetRestaurantByIdQuery : IBaseRequest
    {
        public string ManagementUserId { get; }
        public string RestaurantId { get; }

        public GetRestaurantByIdQuery(string managementUserId, string restaurantId)
        {
            ManagementUserId = managementUserId;
            RestaurantId = restaurantId;
        }
    }
}