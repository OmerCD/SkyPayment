using System;
using System.Collections.Generic;
using System.Text;

namespace SkyPayment.Contract.RequestModel
{
    public class ManagementUserMenuRequestModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string ManagementUserId { get; set; }
    }
}
