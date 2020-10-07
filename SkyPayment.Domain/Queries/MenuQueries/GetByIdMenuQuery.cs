namespace SkyPayment.Domain.Queries
{
    public class GetByIdMenuQuery:IBaseRequest
    {
        public string ManagementUserId { get; }
        public string MenuId { get; }

        public GetByIdMenuQuery(string managementUserId, string menuId)
        {
            ManagementUserId = managementUserId;
            MenuId = menuId;
        }
    }
}