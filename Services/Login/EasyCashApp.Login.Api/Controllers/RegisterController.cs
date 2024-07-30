using EasyCashApp.Login.Business.Interface;
using EasyCashApp.Login.Data.Dto;
using EasyCashApp.SharedClasses.Database.CommonModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashApp.Login.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IService_Register _serviceRegister;

        public RegisterController(IService_Register serviceRegister)
        {
            _serviceRegister = serviceRegister;
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<Dto_CommonResponse> SignIn(Dto_RegisterRequest request)
        {
            var response = await _serviceRegister.SignUpUser(request);
            return response;
        }
    }
}
