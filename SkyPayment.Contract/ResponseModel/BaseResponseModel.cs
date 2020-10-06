namespace SkyPayment.Contract.ResponseModel
{
    public class BaseResponseModel
    {
        public int StatusCode { get; set; }
        public object Data { get; set; }
        public string Description { get; set; }
    }
}