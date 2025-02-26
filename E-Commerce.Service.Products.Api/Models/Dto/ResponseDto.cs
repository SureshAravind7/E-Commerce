namespace E_Commerce.Service.Products.Api.Models.Dto
{
    public class ResponseDto
    {
        public object? Result { get; set; }
        public string? errorMessage { get; set; }
        public bool isSuccess { get; set; }

    }
}
