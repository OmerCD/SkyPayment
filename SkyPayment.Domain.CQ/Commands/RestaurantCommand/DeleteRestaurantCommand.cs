namespace SkyPayment.Domain.CQ.Commands.RestaurantCommand
{
    public class DeleteRestaurantCommand:IBaseRequest
    {
        public string ManagementUserId { get; }
        public string RestaurantId { get; }

        public DeleteRestaurantCommand(string managementUserId, string restaurantId)
        {
            ManagementUserId = managementUserId;
            RestaurantId = restaurantId;
        }
    }
}