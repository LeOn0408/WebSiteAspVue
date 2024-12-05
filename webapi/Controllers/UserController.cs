using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using webapi.Filter;
using webapi.Model.DTO;
using webapi.Model.Entities;
using webapi.Services.User;

namespace webapi.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private IUserService _userService;
    private IConfiguration _configuration;

    public UserController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    //[Authorize]
    [HttpGet]
    public ActionResult<UserDto> Get(int id)
    {
        try
        {
            return _userService.Get(id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize(Roles = "admin")]
    [HttpGet][Route("isadmin")]
    public ActionResult<bool> CheckAdmin()
    {
        
        return true;
    }
}
