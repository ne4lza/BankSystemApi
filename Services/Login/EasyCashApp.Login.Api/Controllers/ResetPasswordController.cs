using EasyCashApp.Login.Business.Interface;
using EasyCashApp.Login.Data.Dto;
using EasyCashApp.SharedClasses.Database.CommonModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashApp.Login.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResetPasswordController : ControllerBase
    {
        private readonly IService_ResetPassword _service_ResetPassword;

        public ResetPasswordController(IService_ResetPassword service_ResetPassword)
        {
            _service_ResetPassword = service_ResetPassword;
        }

        [HttpPost]
        [Route("ResetUserPassword")]
        public async Task<Dto_CommonResponse> ResetUserPassword(Dto_ResetPasswordRequest request)
        {
            var response = await _service_ResetPassword.ResetUserPassword(request);
            return response;
        }
    }
}
