using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Model.User;
using webapi.Services.User;

namespace webapi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly AuthenticateService _authenticateService;

        public AuthentificationController(IUserService userService,IConfiguration configuration, AuthenticateService authenticateService)
        {
            _userService = userService;
            _configuration = configuration;
            _authenticateService = authenticateService;
        }

        [Route("authenticate")]
        [HttpPost]
        public ActionResult<AuthenticatedUser> GetAuthentification(AuthorizationData authorization)
        {
            AuthenticatedUser authenticatedUser = _authenticateService.GetAuthenticatedUser(authorization.Username, authorization.HashPass);

            if (!authenticatedUser.IsUserValid)
            {
                return Unauthorized(authenticatedUser?.ErrorMessage ?? "Token receipt error");
            }
            string? token = authenticatedUser?.RefreshToken?.Token ;
            if(token == null)
            {
                return Unauthorized("Token receipt error");
            }

            HttpContext.Response.Cookies.Append(".AspCore.Refresh.Token",token,
                new CookieOptions
                {
                    MaxAge = authenticatedUser?.RefreshToken?.TokenExpiryDate - DateTime.Now
                });
            return authenticatedUser;
        }

        [Route("refresh-token")]
        [HttpPost]
        public ActionResult<AuthenticatedUser> AuthenticateByRefreshToken()
        {
            var token = HttpContext.Request.Cookies[".AspCore.Refresh.Token"];
            var authenticatedUser = _authenticateService.GetAuthenticatedUserByRefreshToken(token);
            if (!authenticatedUser.IsUserValid)
            {
                return Unauthorized(authenticatedUser.ErrorMessage);
            }
            HttpContext.Response.Cookies.Append(".AspCore.Refresh.Token", authenticatedUser?.RefreshToken?.Token.ToString(),
                new CookieOptions
                {
                    MaxAge = authenticatedUser?.RefreshToken?.TokenExpiryDate - DateTime.Now
                });
            return authenticatedUser;
        }

        [Authorize]
        [HttpGet][Route("validate")]
        public IActionResult Validate()
        {
            return Ok("API Validated");
        }

    }
    public record AuthorizationData(string Username, string HashPass);
}
