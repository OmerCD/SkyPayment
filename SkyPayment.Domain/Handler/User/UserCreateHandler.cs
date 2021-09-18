using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using MediatR;
using SkyPayment.Infrastructure.Services;

namespace SkyPayment.Domain.Handler.User
{
    public class UserCreateHandler:IRequestHandler<UserCreateCommand,bool>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserCreateHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public Task<bool> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Core.Entities.User>(request);
            var userCreate = _userService.UserCreate(user);
            return Task.FromResult(userCreate);
        }
    }
}