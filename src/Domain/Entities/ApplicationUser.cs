using Domain.Common;
using Domain.Enums;
namespace Domain.Entities;

public class ApplicationUser : BaseEntity
{
    public string UserName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public UserRole Role { get; set; } = UserRole.User;

    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}