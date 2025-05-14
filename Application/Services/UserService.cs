using Application.DTO;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;

namespace Application.Services;

public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
{
    public async Task<AuthResponse?> Login(LoginRequest request)
    {
        var user = await userRepository.GetUserByEmailAsync(request.Email, request.Password);
        return user == null 
            ? null 
            : mapper.Map<AuthResponse>(user) with{ Success = true, Token = "token123xy"};
    }

    public async Task<AuthResponse?> Register(RegisterRequest request)
    {
        // Convert DTO to Entity
        var  user = mapper.Map<ApplicationUser>(request);
        
        var registeredUser =  await userRepository.InsertUserAsync(user);
        
        // Convert Entity to DTO
        return registeredUser == null 
            ? null 
            : mapper.Map<AuthResponse>(registeredUser) with{ Success = true, Token = "token123xy"};
        
    }
}