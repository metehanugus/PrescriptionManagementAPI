using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PrescriptionManagementAPI.Data;
using PrescriptionManagementAPI.Models;
using PrescriptionManagementAPI.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace PrescriptionManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly TokenService _tokenService;
        private readonly PrescriptionManagementContext _context;
        


        public AuthController(AuthService authService, TokenService tokenService, PrescriptionManagementContext context)
        {
            _authService = authService;
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserCredentials credentials)
        {
            // Validate the provided credentials
            var user = _context.Users.SingleOrDefault(u => u.Username == credentials.Username);
            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            var passwordHash = Encoding.UTF8.GetString(user.PasswordHash);
            if (!BCrypt.Net.BCrypt.Verify(credentials.Password, passwordHash))
            {
                return Unauthorized("Invalid username or password.");
            }

            // Generate JWT token
            var token = _tokenService.GenerateToken(new User { Username = user.Username });

            return Ok(new { token });
        }

    }
}
