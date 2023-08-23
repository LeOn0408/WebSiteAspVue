using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using webapi.Data.Dto.User;

namespace webapi.Data.User
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _applicationContext;

        public UserService(IConfiguration configuration, DataContext applicationContext)
        {
            _configuration = configuration;
            _applicationContext = applicationContext;
        }

        public int Add(UserDto entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(UserDto entity)
        {
            throw new NotImplementedException();
        }

        public UserDto Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(UserDto entity)
        {
            throw new NotImplementedException();
        }

    }
}
