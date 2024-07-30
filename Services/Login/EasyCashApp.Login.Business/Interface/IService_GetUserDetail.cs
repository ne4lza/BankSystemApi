using EasyCashApp.Login.Data.Dto;

namespace EasyCashApp.Login.Business.Interface
{
    public interface IService_GetUserDetail
    {
        public Task<Dto_GetUserDetailResponse> GetUserDetal(Dto_GetUserDetailRequest request);
    }
}
