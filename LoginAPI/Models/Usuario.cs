namespace LoginAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Identificacion { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
    }
}
