using System;

namespace SkyPayment.Contract.ResponseModel.Authentication
{
    public class CustomerLoginResponseModel
    {
        public string Token { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}