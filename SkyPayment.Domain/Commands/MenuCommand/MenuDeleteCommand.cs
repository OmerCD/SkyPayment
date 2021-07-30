using MediatR;

namespace SkyPayment.Domain.Commands
{
    public class MenuDeleteCommand:IRequest<bool>
    {
        public string Id { get; set; }

        public MenuDeleteCommand(string id)
        {
            Id = id;
        }

        
    }
}