using EasyCashApp.Login.Business.Interface;
using EasyCashApp.Login.Data.Dto;
using EasyCashApp.SharedClasses.Database.CommonModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashApp.Login.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteUserController : ControllerBase
    {
        private readonly IService_DeleteUser _service_DeleteUser;

        public DeleteUserController(IService_DeleteUser service_DeleteUser)
        {
            _service_DeleteUser = service_DeleteUser;
        }

        [HttpPost]
        public async Task<Dto_CommonResponse> DeleteUser(Dto_DeleteUserRequest request)
        {
            var response = await _service_DeleteUser.DeleteUser(request);
            return response;
        }
    }
}
