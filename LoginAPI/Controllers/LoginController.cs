using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginAPI.Data;
using LoginAPI.Models;

namespace LoginAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Identificacion) || string.IsNullOrEmpty(request.Password))
                {
                    return BadRequest(new LoginResponse 
                    { 
                        Success = false, 
                        Message = "Identificación y password son requeridos" 
                    });
                }

                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.Identificacion == request.Identificacion && u.Password == request.Password);

                if (usuario == null)
                {
                    return Unauthorized(new LoginResponse 
                    { 
                        Success = false, 
                        Message = "Credenciales inválidas" 
                    });
                }

                return Ok(new LoginResponse 
                { 
                    Success = true, 
                    Nombre = usuario.Nombre,
                    Message = "Login exitoso" 
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new LoginResponse 
                { 
                    Success = false, 
                    Message = "Error interno del servidor" 
                });
            }
        }
    }
}
