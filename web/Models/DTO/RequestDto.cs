using web.Utility;
using static web.Utility.SD;

namespace web.Models.DTO
{
    public class RequestDto
    {
        public ApiTypes Apitype { get; set; } = ApiTypes.GET;
        public object Data { get; set; }=string.Empty;
        public string Url {  get; set; }= string.Empty;
        public string Token {  get; set; }= string.Empty;
    }
}