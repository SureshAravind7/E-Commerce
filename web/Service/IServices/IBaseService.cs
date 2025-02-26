
using E_Commerce.Web.Models.DTO;
using web.Models.DTO;

namespace web.Service.IServices
{
    public interface IBaseService
    {
        Task<ResponseDto?> sendRequestAsync(RequestDto requestDto,bool withBearer=true);
    }
}
