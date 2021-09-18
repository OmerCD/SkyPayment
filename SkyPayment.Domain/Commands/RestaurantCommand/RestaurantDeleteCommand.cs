using MediatR;

namespace SkyPayment.Domain.Commands.RestaurantCommand
{
    public record RestaurantDeleteCommand(string Id) :IRequest<bool>
    {
        
    }
}