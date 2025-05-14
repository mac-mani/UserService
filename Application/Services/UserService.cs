using Application.DTO;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
{
    private readonly PasswordHasher<string> _passwordHasher = new();

    public string HashPassword(string email, string password)
    {
        return _passwordHasher.HashPassword(email, password);
    }
    public bool VerifyPassword(string email, string enteredPassword, string storedHash)
{
    var result = _passwordHasher.VerifyHashedPassword(email, storedHash, enteredPassword);
    return result == PasswordVerificationResult.Success;
}
    public async Task<AuthResponse?> Login(LoginRequest request)
    {
        var user = await userRepository.GetUserByEmailAsync(request.Email);

        if(user != null && VerifyPassword(request.Email,request.Password,user.Password)){
            return mapper.Map<AuthResponse>(user) with{ Success = true, Token = "token123xy"};
        }        
        return null;
    }

    public async Task<AuthResponse?> Register(RegisterRequest request)
    {
        // Convert DTO to Entity
        var  user = mapper.Map<ApplicationUser>(request);
        user.Password = HashPassword(request.Email,request.Password);
        
        var registeredUser =  await userRepository.InsertUserAsync(user);
        
        // Convert Entity to DTO
        return registeredUser == null 
            ? null 
            : mapper.Map<AuthResponse>(registeredUser) with{ Success = true, Token = "token123xy"};
        
    }
}