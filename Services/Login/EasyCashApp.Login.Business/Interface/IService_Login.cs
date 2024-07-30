using EasyCashApp.Login.Data.Dto;
using EasyCashApp.SharedClasses.Database.CommonModels;

namespace EasyCashApp.Login.Business.Interface
{
    public interface IService_Login
    {
        Task<Dto_CommonResponse> SignInUser(Dto_LoginRequest request);
    }
}
