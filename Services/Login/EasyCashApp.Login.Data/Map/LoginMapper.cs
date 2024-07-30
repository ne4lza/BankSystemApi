using AutoMapper;
using EasyCashApp.Login.Data.Dto;
using EasyCashApp.Login.Data.Model;

namespace EasyCashApp.Login.Data.Map
{
    public class LoginMapper : Profile
    {
        public LoginMapper()
        {
            //LOGIN
            CreateMap<Model_LoginRequest, Dto_LoginRequest>().ReverseMap();
            //CreateMap<Model_LoginResponse, Dto_LoginResponse>().ReverseMap();
        }
    }
}
