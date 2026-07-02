using Application.DTOs.Auth;

namespace Application.Interfaces;

public interface IAuthService
{
    Task<TokenResponseDto> LoginAsync(LoginDto dto);
    Task RegisterAsync(RegisterDto dto);
    Task<TokenResponseDto> RefreshTokenAsync(string refreshToken);
}