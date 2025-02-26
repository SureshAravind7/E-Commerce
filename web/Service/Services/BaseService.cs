using E_Commerce.Web.Models.DTO;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using web.Models.DTO;
using web.Service.IServices;
using web.Utility;
using static web.Utility.SD;

namespace web.Service.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ITokenProvider tokenProvider;
        public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
        {

            this.httpClientFactory = httpClientFactory;
            this.tokenProvider = tokenProvider;

        }
        public async Task<ResponseDto?> sendRequestAsync(RequestDto requestDto, bool withBearer = true)
        {
            try
            {
                HttpClient httpClient = httpClientFactory.CreateClient("Coupon");
                HttpRequestMessage message = new();

                if(withBearer)
                {
                    var token =tokenProvider.GetToken();
                    message.Headers.Add("Authorization", $"Bearer {token}");
                }

                message.RequestUri = new Uri(requestDto.Url);

                if (requestDto.Data != null)
                {

                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }

                switch (requestDto.Apitype)
                {
                    case ApiTypes.POST:
                        message.Method = HttpMethod.Post;
                        break;

                    case ApiTypes.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiTypes.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;

                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage? apiResponse = null;

                apiResponse = await httpClient.SendAsync(message);

                switch (apiResponse.StatusCode)
                {

                    case HttpStatusCode.NotFound:
                        return new() { isSuccess = false, errorMessage = "Not found" };

                    case HttpStatusCode.Unauthorized:
                        return new()
                        {
                            isSuccess = false,
                            errorMessage = "Invalid Access"
                        };
                    case HttpStatusCode.Forbidden: return new() { isSuccess = false, errorMessage = "Access denied" };

                    case HttpStatusCode.InternalServerError: return new() { isSuccess = false, errorMessage = "Internal Server Error" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiresponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiresponseDto;
                }
            }
            catch (Exception e)
            {
                return new ResponseDto()
                {
                    isSuccess = false,
                    errorMessage = e.Message,
                };
            }
            {

            }
            
        }
    }
}
