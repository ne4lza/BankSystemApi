using EasyCashApp.Login.Business.Interface;
using EasyCashApp.Login.Data.Dto;
using EasyCashApp.SharedClasses.Database.CommonModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashApp.Login.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        private readonly IService_GetUserDetail _service_GetUserDetail;

        public UserDetailController(IService_GetUserDetail service_GetUserDetail)
        {
            _service_GetUserDetail = service_GetUserDetail;
        }

        [HttpPost]
        [Route("GetUserDetail")]
        public async Task<Dto_GetUserDetailResponse> GetUserDetail(Dto_GetUserDetailRequest request)
        {
            var response = await _service_GetUserDetail.GetUserDetal(request);
            return response;
        }
    }
}
