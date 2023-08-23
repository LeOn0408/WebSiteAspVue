using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Data.Dto.User
{
    [Table("ap_users_entity")]
    public class UserEntity:EntityDto
    {
        public int UserId { get; set; }
        public UserDto User { get; set; }
    }
}
