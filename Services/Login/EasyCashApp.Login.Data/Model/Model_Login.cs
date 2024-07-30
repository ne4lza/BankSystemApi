namespace EasyCashApp.Login.Data.Model
{
    public class Model_LoginRequest
    {
        public string? Tckn { get; set; }
        public string? Password { get; set; }
    }

    public class Model_LoginResponse
    {
        public int? StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
