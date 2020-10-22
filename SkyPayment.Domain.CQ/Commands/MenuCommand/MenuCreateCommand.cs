using System;

namespace SkyPayment.Domain.CQ.Commands.MenuCommand
{
    public class MenuCreateCommand:IBaseRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string ManagementUserId { get; set; }
        public MenuCreateCommand(string name, DateTime dateTime, string managementUserId)
        {
            Name = name;
            CreateDateTime = dateTime;
            ManagementUserId = managementUserId;
        }
    }
}