using Mapster;
using MapsterMapper;
using webapi.Model.DTO;
using webapi.Model.Entities;

namespace webapi.Services.User;

public class UserService : IUserService
{
    private readonly IConfiguration _configuration;
    private readonly DataContext _applicationContext;

    public UserService(IConfiguration configuration, DataContext applicationContext)
    {
        _configuration = configuration;
        _applicationContext = applicationContext;
    }

    public int Add(UserDto dto)
    {
        throw new NotImplementedException();
    }

    public bool Delete(UserDto dto)
    {
        throw new NotImplementedException();
    }

    public UserDto Get(int id)
    {
        UserEntity userEntity = _applicationContext.Users.FirstOrDefault(u => u.Id == id) ?? throw new InvalidOperationException();
        UserDto user = userEntity.Adapt<UserDto>();
        return user;
    }

    public IEnumerable<UserDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public bool Update(UserDto dto)
    {
        throw new NotImplementedException();
    }

}
