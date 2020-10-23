using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Management.API.Helper;
using SkyPayment.Contract.RequestModel;
using SkyPayment.Contract.RequestModel.Authentication;
using SkyPayment.Domain.CQ.Commands.AuthenticationCommands;
using SkyPayment.Domain.Helpers;

namespace SkyPayment.Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public RegisterController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterModel registerModel)
        {
            var command = new ManagementUserRegisterCommand(registerModel.Email,registerModel.Name,registerModel.Password, registerModel.LastName, registerModel.UserName);
            var response = await _mediator.Send(command);
            return response.ToActionResult();
        }

        [HttpPost("personnel")]
        public async Task<IActionResult> RegisterPersonnel([FromBody] PersonnelRegisterCreateModel createModel)
        {
            var command = _mapper.Map<PersonnelUserRegisterCommand>(createModel);
            command.ManagementUserId = User.GetManagementUserId();
            var response = await _mediator.Send(command);
            return response.ToActionResult();
        }
    }
}