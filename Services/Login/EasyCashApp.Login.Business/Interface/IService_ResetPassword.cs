using EasyCashApp.Login.Data.Dto;
using EasyCashApp.SharedClasses.Database.CommonModels;

namespace EasyCashApp.Login.Business.Interface
{
    public interface IService_ResetPassword
    {
        Task<Dto_CommonResponse> ResetUserPassword(Dto_ResetPasswordRequest request);
    }
}
