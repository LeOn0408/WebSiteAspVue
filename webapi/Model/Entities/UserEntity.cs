using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace webapi.Model.Entities;

[Table("ap_users")]
public class UserEntity
{
    public int Id { get; set; }

    [Required]
    public required string UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public required string Email { get; set; }

    [JsonIgnore]
    public string Password { get; set; } = null!;

    [JsonIgnore]
    public bool IsAdmin { get; set; } = false;

}