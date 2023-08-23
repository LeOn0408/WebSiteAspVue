﻿using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.Data.Dto.User;
using webapi.Services;

namespace webapi.Data.User
{
    public class AuthenticateService
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _applicationContext;

        public AuthenticateService(IConfiguration configuration, DataContext applicationContext)
        {
            _configuration = configuration;
            _applicationContext = applicationContext;
        }

        public AuthenticatedUser GetAuthenticatedUser(string login, string hashPass) 
        {
            AuthenticatedUser authenticatedUser;
            if (login == "admin")
            {
                authenticatedUser = GetAuthenticateAdmin(hashPass);
            }
            else
            {
                //TODO: Сделать для других пользователей
                return new AuthenticatedUser("Доступ только для администраторов");
            }
            if (authenticatedUser.IsUserValid)
            {
                authenticatedUser.SetJwtToken(GetJwtToken(login));
                authenticatedUser.SetRefreshToken(CreateRefreshToken(authenticatedUser));

            }
            return authenticatedUser;
        }
        public AuthenticatedUser GetAuthenticatedUserByRefreshToken(string refreshToken)
        {
            var token = _applicationContext.RefreshToken.Include(u => u.User).FirstOrDefault(t=>t.Token==refreshToken);
            if(token is null || token.TokenExpiryDate < DateTime.UtcNow)
            {
                return new AuthenticatedUser("Недействительный токен");
            }
            var user = _applicationContext.Users.FirstOrDefault(x => x.Id == token.User.Id);
            if (user == null)
            {
                return new AuthenticatedUser("Недействительный токен");
            }
            var authenticatedUser = new AuthenticatedUser(user);
            authenticatedUser.SetJwtToken(GetJwtToken(user.UserName));
            authenticatedUser.SetRefreshToken(CreateRefreshToken(authenticatedUser));
            return authenticatedUser;
        }
        private JwtSecurityToken GetJwtToken(string login)
        {
            AuthOptions authOptions = new(_configuration);
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, login) };
            var jwt = new JwtSecurityToken(
                    issuer: authOptions.Issuer,
            audience: authOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)), // время действия 2 минуты
                    signingCredentials: new SigningCredentials(authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return jwt;
        }
        private RefreshToken CreateRefreshToken(AuthenticatedUser user) 
        {
            var token = new RefreshToken();
            token.TokenExpiryDate = DateTime.UtcNow.AddDays(30);
            token.User = user.GetUser();
            token.Token = Guid.NewGuid().ToString();
            SaveTokenToDatabase(token);
            return token; 
        }
        private void SaveTokenToDatabase(RefreshToken token)
        {
            var tokenDatabase = _applicationContext.RefreshToken.FirstOrDefault(t => t.User == token.User);
            if(tokenDatabase is null)
            {
                _applicationContext.RefreshToken.Add(token);
                _applicationContext.SaveChanges();
            }
            else
            {
                tokenDatabase.Token = token.Token;
                tokenDatabase.TokenExpiryDate =token.TokenExpiryDate;
                _applicationContext.SaveChanges();
            }
        }

        private AuthenticatedUser GetAuthenticateAdmin(string hashPassword)
        {
            string passwordSystem = _configuration.GetSection("SecurityPass").Value ?? throw new Exception("SecurityPass not specified");
            var admin = _applicationContext.Users.FirstOrDefault(x => x.UserName == "admin");
            if (admin == null)
            {

                if (!string.IsNullOrEmpty(passwordSystem) && hashPassword == Password.Hash(passwordSystem))
                {
                    admin = new UserDto()
                    {
                        UserName = "admin",
                        Password = Password.Hash(passwordSystem),
                        Email = _configuration.GetSection("AdminMail").Value ?? "enter_your_email@mail.com"
                    };
                    admin.FirstName ??= admin.UserName;
                    admin.LastName ??= admin.UserName;
                    _applicationContext.Users.Add(admin);
                    _applicationContext.SaveChanges();
                }
                else
                {
                    return new AuthenticatedUser("Error! Invalid username/password.");
                }
            }

            if (admin.Password == hashPassword || hashPassword == Password.Hash(passwordSystem))
            {
                return new AuthenticatedUser(admin);
            }
            else
            {
                return new AuthenticatedUser("Error! Invalid username/password.");
            }
        }
    }
}

