

using webapi.Model.DTO;

namespace webapi.Services.User;

public interface IUserService
{
    public int Add(UserDto entity);
    public bool Delete(UserDto entity);
    public bool Update(UserDto entity);
    public UserDto Get(int id);
    public IEnumerable<UserDto> GetAll();
}