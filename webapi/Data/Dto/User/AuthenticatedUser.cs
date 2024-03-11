using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;

namespace webapi.Data.Dto.User
{
    public class AuthenticatedUser
    {
        public int Id { get; set; }
        public string? JwtToken { get; private set; }
        [JsonIgnore]
        public RefreshToken? RefreshToken { get; private set; }

        public string? ErrorMessage { get;}     

        [JsonIgnore]
        public bool IsUserValid { get; }

        public UserDto? User { get; init; }

        public AuthenticatedUser(UserDto userDto)
        {
            Id = userDto.Id;
            User = userDto;
            IsUserValid = true;
        }

        public AuthenticatedUser(string errorMessage)
        {
            ErrorMessage = errorMessage;
            User = null;
        }
        public void SetJwtToken(JwtSecurityToken jwt)
        {
            JwtToken = new JwtSecurityTokenHandler().WriteToken(jwt);
        }
        public void SetRefreshToken(RefreshToken token)
        {
            RefreshToken = token;
        }
    }
}
