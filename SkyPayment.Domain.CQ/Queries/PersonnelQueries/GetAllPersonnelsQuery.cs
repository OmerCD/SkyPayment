namespace SkyPayment.Domain.CQ.Queries.PersonnelQueries
{
    public class GetAllPersonnelsQuery : IBaseRequest
    {
        public string ManagementUserId { get; }

        public GetAllPersonnelsQuery(string managementUserId)
        {
            ManagementUserId = managementUserId;
        }
    }
}