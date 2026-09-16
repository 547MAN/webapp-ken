using BecomeAWizzard.Api.DTOs;
using BecomeAWizzard.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BecomeAWizzard.Api.Controllers;

// TASK 8 STARTER
// This controller depends on AuthService and ASP.NET Core cookie authentication configured in Program.cs.
// Keep route names unchanged because client/src/api/authApi.js already consumes this contract.
[ApiController, Route("api/auth")]
public class AuthController(AuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public Task<ActionResult<UserDto>> Register(RegisterRequest request)
    {
        // TODO 8.3: call RegisterAsync, create a ClaimsPrincipal, issue the cookie and return UserDto.
        throw new NotImplementedException("Task 8: implement POST /api/auth/register.");
    }

    [HttpPost("login")]
    public Task<ActionResult<UserDto>> Login(LoginRequest request)
    {
        // TODO 8.4: validate credentials, return 401 on failure and issue the same cookie on success.
        throw new NotImplementedException("Task 8: implement POST /api/auth/login.");
    }

    [HttpGet("me")]
    public ActionResult<UserDto> Me()
    {
        // TODO 8.5: protect with [Authorize] and map the current claims to UserDto.
        return StatusCode(StatusCodes.Status501NotImplemented);
    }

    [HttpPost("logout")]
    public Task<IActionResult> Logout()
    {
        // TODO 8.6: protect with [Authorize], sign out the cookie and return HTTP 204.
        throw new NotImplementedException("Task 8: implement POST /api/auth/logout.");
    }
}
