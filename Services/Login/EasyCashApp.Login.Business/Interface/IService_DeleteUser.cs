using EasyCashApp.Login.Data.Dto;
using EasyCashApp.SharedClasses.Database.CommonModels;

namespace EasyCashApp.Login.Business.Interface
{
    public interface IService_DeleteUser
    {
        public Task<Dto_CommonResponse> DeleteUser(Dto_DeleteUserRequest request);
    }
}
