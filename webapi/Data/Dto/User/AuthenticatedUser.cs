using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;

namespace webapi.Data.Dto.User
{
    public class AuthenticatedUser
    {
        public string? JwtToken { get; private set; }
        [JsonIgnore]
        public RefreshToken? RefreshToken { get; private set; }
        public string? ErrorMessage { get;}
        public string? Email { get; }
        public string? Username { get; }

        [JsonIgnore]
        public bool IsUserValid { get; }

        private UserDto? _user;

        public AuthenticatedUser(UserDto userDto)
        {
            Email = userDto.Email;
            Username = userDto.UserName;
            IsUserValid = true;
            _user = userDto;
        }

        public AuthenticatedUser(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        public void SetJwtToken(JwtSecurityToken jwt)
        {
            JwtToken = new JwtSecurityTokenHandler().WriteToken(jwt);
        }
        public void SetRefreshToken(RefreshToken token)
        {
            RefreshToken = token;
        }
        public UserDto GetUser()
        {
            return _user;
        }
    }
}
