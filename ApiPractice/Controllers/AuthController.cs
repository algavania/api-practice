using ApiPractice.Services;
using ApiPractice.Domain.DTOs;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RegisterRequest = ApiPractice.Domain.DTOs.RegisterRequest;

namespace ApiPractice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(AuthService authService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                Console.WriteLine($"Login request: {request}");
                var token = await authService.LoginAsync(request.Email, request.Password);

                var response = ApiResponse<string>.Success("Login successful", token);
                return Ok(response);
            }
            catch (Exception e)
            {
                var errorResponse = ApiResponse<string>.Error(e.Message);
                return BadRequest(errorResponse);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                var token = await authService.RegisterAsync(request.Name, request.Email, request.Password);
                var response = ApiResponse<string>.Success("Registration successful", token);
                return Ok(response);
            }
            catch (Exception e)
            {
                var errorResponse = ApiResponse<string>.Error(e.Message);
                return BadRequest(errorResponse);
            }
        }
    }
}
