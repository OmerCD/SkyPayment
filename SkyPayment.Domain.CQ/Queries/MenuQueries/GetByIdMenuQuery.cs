namespace SkyPayment.Domain.CQ.Queries.MenuQueries
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