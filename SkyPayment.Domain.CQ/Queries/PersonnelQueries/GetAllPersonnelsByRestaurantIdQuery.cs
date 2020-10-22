namespace SkyPayment.Domain.CQ.Queries.PersonnelQueries
{
    public class GetAllPersonnelsByRestaurantIdQuery : IBaseRequest
    {
        public string ManagementUserId { get; }
        public string RestaurantId { get; }

        public GetAllPersonnelsByRestaurantIdQuery(string managementUserId, string restaurantId)
        {
            ManagementUserId = managementUserId;
            RestaurantId = restaurantId;
        }
    }
}