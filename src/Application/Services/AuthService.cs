using Application.DTOs.Auth;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtService _jwtService;
private readonly IPasswordHasher _passwordHasher;
    public AuthService(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IJwtService jwtService,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
        _passwordHasher = passwordHasher;
    }

    public async Task RegisterAsync(RegisterDto dto)
    {
        var existing = await _userRepository.GetByEmailAsync(dto.Email);

        if (existing != null)
            throw new Exception("User already exists.");

        var user = new ApplicationUser
        {
            UserName = dto.UserName,
            Email = dto.Email,
            PasswordHash = _passwordHasher.Hash(dto.Password),
            Role = Domain.Enums.UserRole.User,
            CreatedBy = "System",
            CreatedOn = DateTime.UtcNow
        };

        await _userRepository.AddAsync(user);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<TokenResponseDto> LoginAsync(LoginDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email);

        if (user == null)
            throw new Exception("Invalid credentials.");

        var valid = _passwordHasher.Verify(dto.Password, user.PasswordHash);

        if (!valid)
            throw new Exception("Invalid credentials.");

        return new TokenResponseDto
        {
            AccessToken = _jwtService.GenerateToken(user),
            RefreshToken = _jwtService.GenerateRefreshToken()
        };
    }

    public Task<TokenResponseDto> RefreshTokenAsync(string refreshToken)
    {
        throw new NotImplementedException();
    }
}