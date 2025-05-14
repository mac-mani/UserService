using Application.DTO;

namespace Application.IServices;

public interface IUserService
{
    Task<AuthResponse?> Login(LoginRequest request);
    Task<AuthResponse?> Register(RegisterRequest request);
}