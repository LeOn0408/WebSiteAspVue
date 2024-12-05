using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Model.Entities;

[Table("ap_refresh_token")]
public class RefreshTokenEntity
{
    public int Id { get; set; }
    public string? Token { get; set; }
    public UserEntity? User { get; set; }
    public DateTime TokenExpiryDate { get; set; }
}
