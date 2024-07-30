using EasyCashApp.Login.Data.Dto;
using EasyCashApp.SharedClasses.Database.CommonModels;

namespace EasyCashApp.Login.Business.Interface
{
    public interface IService_Register
    {
        Task<Dto_CommonResponse> SignUpUser(Dto_RegisterRequest request);
    }
}
