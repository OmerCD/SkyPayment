using System;
using System.Collections.Generic;
using System.Text;

namespace SkyPayment.Domain.Commands.UserMenuCommand
{
    public class CreateUserMenuCommand: IBaseRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string ManagementUserId { get; set; }
        public CreateUserMenuCommand(string name, DateTime dateTime, string managementUserId)
        {
            Name = name;
            CreateDateTime = dateTime;
            ManagementUserId = managementUserId;
        }
    }
}
