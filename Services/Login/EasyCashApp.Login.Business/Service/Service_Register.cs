using EasyCashApp.Login.Business.Interface;
using EasyCashApp.Login.Data.Dto;
using EasyCashApp.SharedClasses.Database.AppContext;
using EasyCashApp.SharedClasses.Database.CommonModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EasyCashApp.Login.Business.Service
{
    public class Service_Register : IService_Register
    {
        private readonly EasyCashAppDbContext _context;

        public Service_Register(EasyCashAppDbContext context)
        {
            _context = context;
        }

        public async Task<Dto_CommonResponse> SignUpUser(Dto_RegisterRequest request)
        {
            var response = new Dto_CommonResponse();

            try
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SP_EC_USER";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int) { Value = 2 });
                    command.Parameters.Add(new SqlParameter("@Tckn", SqlDbType.NVarChar, 11) { Value = request.Tckn ?? (object)DBNull.Value });
                    command.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar, 6) { Value = request.Password ?? (object)DBNull.Value });
                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50) { Value = request.Name ?? (object)DBNull.Value });
                    command.Parameters.Add(new SqlParameter("@MiddleName", SqlDbType.NVarChar, 50) { Value = request.MiddleName ?? (object)DBNull.Value });
                    command.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 50) { Value = request.LastName ?? (object)DBNull.Value });
                    command.Parameters.Add(new SqlParameter("@MonthlyIncome", SqlDbType.Int) { Value = request.MonthlyIncome.HasValue ? (object)request.MonthlyIncome.Value : DBNull.Value });

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
                response.StatusCode = 0;
                response.Message = ex.Message;
                return response;
            }


        }
    }
}
