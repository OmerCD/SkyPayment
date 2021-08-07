using System.Collections.Generic;
using MediatR;
using SkyPayment.Shared;

namespace SkyPayment.Domain.Queries.MenuQueries
{
    public class GetMenuByManagerIdQueries : IRequest<IEnumerable<MenuResponseModel>>
    {
        public string ManagerId { get; set; }

        public GetMenuByManagerIdQueries(string managerId)
        {
            ManagerId = managerId;
        }
    }
}