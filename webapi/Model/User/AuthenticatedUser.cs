﻿using System.IdentityModel.Tokens.Jwt;
using System.Text.Json.Serialization;
using webapi.Model.DTO;
using webapi.Model.Entities;

namespace webapi.Model.User;

public class AuthenticatedUser
{
    public int Id { get; set; }
    public string? JwtToken { get; private set; }
    [JsonIgnore]
    public RefreshTokenEntity? RefreshToken { get; private set; }

    public string? ErrorMessage { get; }

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
    public void SetRefreshToken(RefreshTokenEntity token)
    {
        RefreshToken = token;
    }
}
