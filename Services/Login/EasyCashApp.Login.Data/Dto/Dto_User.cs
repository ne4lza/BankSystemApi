
namespace EasyCashApp.Login.Data.Dto
{
    public class Dto_LoginRequest
    {
        public string? Tckn { get; set; }
        public string? Password { get; set; }
    }
    public class User
    {
        public int? Id { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? UserDetailId { get; set; }
        public string? Password { get; set; }
        public string? OldPassword { get; set; }
    }

    public class UserDetail
    {
        public int? Id { get; set;}
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Name { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Tckn { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public decimal? MonthlyIncome { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? DeleteReason { get; set; }
        public DateTime? KvkkApproveDate { get; set; }
    }

    public class Dto_RegisterRequest
    {
        public string? Name { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Tckn { get; set; }
        public int? MonthlyIncome { get; set; }
        public string? Password { get; set; }
    }

    public class Dto_ResetPasswordRequest
    {
        public int? UserId { get; set; }
        public string? Password { get; set; }
    }

    public class Dto_GetUserDetailRequest
    {
        public int? UserId { get; set; }
    }

    public class Dto_GetUserDetailResponse
    {
        public int? UserId { get; set; }
        public string? Name { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Tckn { get; set; }
        public string? ApiKey { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }

    public class Dto_DeleteUserRequest
    {
        public int? UserId { get; set; }
    }

}
