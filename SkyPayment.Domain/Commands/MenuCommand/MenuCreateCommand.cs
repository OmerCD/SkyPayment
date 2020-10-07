using System;
using SkyPayment.Core.Entities;

namespace SkyPayment.Domain.Commands.MenuCommand
{
    public class MenuCreateCommand:IBaseRequest
    {
        private string Name { get; set; }
        public string Type { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string ManagementUserId { get; set; }
        public MenuCreateCommand(string name, string type, DateTime dateTime, string managementUserId)
        {
            Name = name;
            Type = type;
            CreateDateTime = dateTime;
            ManagementUserId = managementUserId;
        }
    }
}