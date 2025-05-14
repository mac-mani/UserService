using Application.DTO;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class AuthController(IUserService userService) : BaseApiController
{
    // GET
    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse?>> Register(RegisterRequest request)
    {
        if(request == null) return BadRequest();
        
        var authResponse = await userService.Register(request);
        
        return authResponse is not { Success: true }? BadRequest(): Ok(authResponse);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse?>> Login(LoginRequest request)
    {
     
        var authResponse = await userService.Login(request);

        return authResponse is not { Success: true } ? Unauthorized("Invalid email/password") : Ok(authResponse);
    }
}