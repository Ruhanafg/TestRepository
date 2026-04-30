using GroceryApplication.Service;
using GroceryApplication.WebApi.Models;
using GroceryApplication.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroceryApplication.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly JwtService _jwtService;

        public AuthController(AuthService authService, JwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _authService.Register(
                request.Username,
                request.Email,
                request.Password
            );

            if (!result)
                return BadRequest("User already exists");

            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _authService.Login(request.Email, request.Password);

            if (user == null)
                return Unauthorized();

            var token = _jwtService.GenerateToken(user);

            return Ok(new { Token = token });
        }
    }
}