using System.Collections.Generic;
using MediatR;
using SkyPayment.Core.Entities;
using SkyPayment.Shared;

namespace SkyPayment.Domain.Queries.MenuQueries
{
    public class GetAllMenuQueries:IRequest<IEnumerable<MenuResponseModel>>
    {
        
    }
}