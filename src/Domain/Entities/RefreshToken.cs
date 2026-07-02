using Domain.Common;

namespace Domain.Entities;

public class RefreshToken : BaseEntity
{
    public string Token { get; set; } = string.Empty;

    public DateTime Expires { get; set; }

    public bool IsRevoked { get; set; }

    public int ApplicationUserId { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }
}