namespace SkyPayment.Domain.CQ.Commands.MenuCommand
{
    public class DeleteMenuCommand:IBaseRequest
    {
        public string ManagementUserId { get; }
        public string MenuId { get; }

        public DeleteMenuCommand(string managementUserId, string menuId)
        {
            ManagementUserId = managementUserId;
            MenuId = menuId;
        }
    }
}