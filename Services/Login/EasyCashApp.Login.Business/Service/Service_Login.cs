using EasyCashApp.Login.Business.Interface;
using EasyCashApp.Login.Data.Dto;
using EasyCashApp.SharedClasses.Database.AppContext;
using EasyCashApp.SharedClasses.Database.CommonModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace EasyCashApp.Login.Business.Service
{
    public class Service_Login : IService_Login
    {
        private readonly EasyCashAppDbContext _context;

        public Service_Login(EasyCashAppDbContext context)
        {
            _context = context;
        }

        public Task<Dto_CommonResponse> SignInUser(Dto_LoginRequest request)
        {
            
            var response = new Dto_CommonResponse();
            try
            {
                var typeParam = new SqlParameter("@Type","1");
                var tcknParam = new SqlParameter("@Tckn",request.Tckn);
                var passwordParam = new SqlParameter("@Password",request.Password);

                var result = _context.COMMON_RESPONSE.FromSqlRaw("EXEC SP_EC_USER @Type, @Tckn, @Password", 
                                                                                  typeParam, tcknParam, passwordParam)
                                                                                  .AsEnumerable().ToList();
                if(result != null) 
                {
                    var firstResult = result.First();
                    response.StatusCode = firstResult.StatusCode;
                    response.Message = firstResult.Message;
                }
                return Task.FromResult(response);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
