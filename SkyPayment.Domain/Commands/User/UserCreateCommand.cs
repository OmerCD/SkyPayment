using MediatR;

namespace SkyPayment.Domain.Handler.User
{
    public record UserCreateCommand(string Name,string LastName,string UserName,string Email,string PhoneNumber) :IRequest<bool>
    {
    }
}