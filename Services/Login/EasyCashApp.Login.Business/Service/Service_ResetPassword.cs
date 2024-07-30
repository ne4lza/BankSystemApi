using EasyCashApp.Login.Business.Interface;
using EasyCashApp.Login.Data.Dto;
using EasyCashApp.SharedClasses.Database.AppContext;
using EasyCashApp.SharedClasses.Database.CommonModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EasyCashApp.Login.Business.Service
{
    public class Service_ResetPassword : IService_ResetPassword
    {
        private readonly EasyCashAppDbContext _context;

        public Service_ResetPassword(EasyCashAppDbContext context)
        {
            _context = context;
        }

        public async Task<Dto_CommonResponse> ResetUserPassword(Dto_ResetPasswordRequest request)
        {
            var response = new Dto_CommonResponse();

            try
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SP_EC_USER";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int) { Value = 3 });
                    command.Parameters.Add(new SqlParameter("@NewPassword", SqlDbType.NVarChar, 6) { Value = request.Password ?? (object)DBNull.Value });
                    command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int) { Value = request.UserId ?? (object)DBNull.Value });

                    if (command.Connection.State != System.Data.ConnectionState.Open)
                    {
                        command.Connection.Open();
                    }

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            response.StatusCode = reader.GetInt32(reader.GetOrdinal("StatusCode"));
                            response.Message = reader.GetString(reader.GetOrdinal("Message"));
                        }
                        else
                        {
                            response.StatusCode = 0;
                            response.Message = "No results returned.";
                        }
                    }
                }
                return response;

            }
            catch (Exception ex)
            {

                return new Dto_CommonResponse()
                {
                    StatusCode = 0,
                    Message = ex.Message,
                };

            }
        }
    }
}
