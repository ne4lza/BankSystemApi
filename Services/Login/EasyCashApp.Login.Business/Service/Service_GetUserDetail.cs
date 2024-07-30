using EasyCashApp.Login.Business.Interface;
using EasyCashApp.Login.Data.Dto;
using EasyCashApp.SharedClasses.Database.AppContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EasyCashApp.Login.Business.Service
{
    public class Service_GetUserDetail : IService_GetUserDetail
    {
        private readonly EasyCashAppDbContext _context;

        public Service_GetUserDetail(EasyCashAppDbContext context)
        {
            _context = context;
        }

        public async Task<Dto_GetUserDetailResponse> GetUserDetal(Dto_GetUserDetailRequest request)
        {
            var response = new Dto_GetUserDetailResponse();
            try
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SP_EC_USER";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int) { Value = 5 });
                    command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int) { Value = request.UserId ?? (object)DBNull.Value });

                    if (command.Connection.State != System.Data.ConnectionState.Open)
                    {
                        command.Connection.Open();
                    }

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if(reader != null) 
                        {
                            if (await reader.ReadAsync())
                            {
                                response.UserId = reader.GetInt32(reader.GetOrdinal("UserId"));
                                response.Name = reader.GetString(reader.GetOrdinal("Name"));
                                if(response.MiddleName  != null)
                                {
                                    response.MiddleName = reader.GetString(reader.GetOrdinal("MiddleName"));
                                }
                                response.MiddleName = "";
                                response.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                                response.Tckn = reader.GetString(reader.GetOrdinal("Tckn"));
                                response.ApiKey = reader.GetString(reader.GetOrdinal("ApiKey"));
                                response.LastLoginDate = reader.GetDateTime(reader.GetOrdinal("LastLoginDate"));
                            }
                        }
                    }
                    return response;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
