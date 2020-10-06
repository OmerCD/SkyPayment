using System;

namespace SkyPayment.Contract.ResponseModel.Restaurant
{
    public class GetRestaurantByIdResponseModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int TableCount { get; set; }
        public DateTime CreateDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}