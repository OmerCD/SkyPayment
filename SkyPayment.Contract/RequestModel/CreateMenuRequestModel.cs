using System;

namespace SkyPayment.Contract.RequestModel
{
    public class CreateMenuRequestModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime CreateDateTime { get; set; }

    }
}