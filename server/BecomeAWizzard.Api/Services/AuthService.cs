using BecomeAWizzard.Api.Data;
using BecomeAWizzard.Api.DTOs;
using BecomeAWizzard.Api.Models;

namespace BecomeAWizzard.Api.Services;

// TASK 8 STARTER
// AuthController depends on this service. Implement and test this class before enabling the real API in client/.env.development.
// AppDbContext and User are already provided by the data-access task and must not be redesigned here.
public class AuthService(AppDbContext db)
{
    public Task<User> RegisterAsync(RegisterRequest request)
    {
        // TODO 8.1: normalize e-mail, reject duplicates, hash the password and save the new User.
        // Use PasswordHasher<User>; never store or log the clear-text password.
        throw new NotImplementedException("Task 8: implement user registration.");
    }

    public Task<User?> ValidateAsync(LoginRequest request)
    {
        // TODO 8.2: find the normalized e-mail and verify the stored password hash.
        // Return null for invalid credentials so the controller can return HTTP 401.
        throw new NotImplementedException("Task 8: implement credential validation.");
    }
}
