using System;
using System.Collections.Generic;
using System.Text;

namespace SkyPayment.Domain.Commands.UserMenuCommand
{
    public class CreateUserMenuCommand: IBaseRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string ManagementUserId { get; set; }
        public CreateUserMenuCommand(string name, string managementUserId,string type)
        {
            Name = name;
            Type = type;
            ManagementUserId = managementUserId;
        }
    }
}
