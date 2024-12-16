using ApiPractice.Domain.DTOs;
using ApiPractice.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiPractice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(UserService userService) : ControllerBase
{
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUserRequest request)
    {
        try
        {
            var user = await userService.UpdateUserAsync(id, request.Name, request.Email);
            var response = ApiResponse<UserResponse>.Success("Update user successful", user);
            return Ok(response);
        }
        catch (Exception e)
        {
            var errorResponse = ApiResponse<string>.Error(e.Message);
            return BadRequest(errorResponse);
        }
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, [FromBody] UpdateUserRequest request)
    {
        try
        {
            await userService.DeleteUserAsync(id);
            var response = ApiResponse<string?>.Success("Update user successful", null);
            return Ok(response);
        }
        catch (Exception e)
        {
            var errorResponse = ApiResponse<string>.Error(e.Message);
            return BadRequest(errorResponse);
        }
    }
}