namespace LoginAPI.Models
{
    public class LoginRequest
    {
        public string Identificacion { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
