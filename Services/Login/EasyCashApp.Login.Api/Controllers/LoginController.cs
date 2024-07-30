using EasyCashApp.Login.Business.Interface;
using EasyCashApp.Login.Data.Dto;
using EasyCashApp.SharedClasses.Database.CommonModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashApp.Login.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IService_Login _serviceLogin;

        public LoginController(IService_Login serviceLogin)
        {
            _serviceLogin = serviceLogin;
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<Dto_CommonResponse> SignIn(Dto_LoginRequest request)
        {
            var response = await _serviceLogin.SignInUser(request);
            return response;
        }
    }
}
