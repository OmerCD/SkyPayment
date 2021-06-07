namespace SkyPaymentV2.User.API.Models
{
    public class BaseResponseModel<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
    }
}