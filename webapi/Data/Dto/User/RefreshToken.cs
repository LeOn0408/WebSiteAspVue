using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Data.Dto.User
{
    [Table("ap_refresh_token")]
    public class RefreshToken
    {
        public int Id { get; set; }
        public string? Token { get; set; }
        public UserDto? User { get; set; }
        public DateTime TokenExpiryDate { get; set; }
    }
}
