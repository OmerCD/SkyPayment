using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.API.Helper;
using SkyPayment.Domain.CQ.Queries.PersonnelQueries;
using SkyPayment.Domain.Helpers;
using IBaseRequest = SkyPayment.Domain.CQ.IBaseRequest;

namespace SkyPayment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonnelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonnelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersonnels(string restaurantId)
        {
            var managementUserId = User.GetManagementUserId();
            IBaseRequest query;
            if (restaurantId == null)
            {
                query = new GetAllPersonnelsQuery(managementUserId);
            }
            else
            {
                query = new GetAllPersonnelsByRestaurantIdQuery(managementUserId,restaurantId);
            }

            var response = await _mediator.Send(query);
            return response.ToActionResult();
        }
    }
}