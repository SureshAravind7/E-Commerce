namespace E_Commerce.Service.CouponApi.Models.DTO
{
    public class ResponseDto
    {
        public object? result { get; set; }

        public bool isSuccess {  get; set; }

        public string? errorMessage { get; set; }
    }
}
