namespace E_Commerce.Web.Models.DTO
{
    public class ResponseDto
    {
        public object? result { get; set; }

        public bool isSuccess {  get; set; }

        public string? errorMessage { get; set; }
    }
}
