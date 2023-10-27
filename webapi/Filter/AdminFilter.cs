using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using webapi.Data.Dto.User;
using webapi.Data.User;

namespace webapi.Filter
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AdminFilter : Attribute,IAuthorizationFilter
    {
        private DataContext _applicationContext;

        public AdminFilter(DataContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var refreshToken = context.HttpContext.Request.Cookies[".AspCore.Refresh.Token"];
            var token = _applicationContext.RefreshToken.Include(u => u.User).FirstOrDefault(t => t.Token == refreshToken);
            if (token != null)
            {
                UserDto? user = _applicationContext.Users.FirstOrDefault(x => x.Id == token.User.Id);
                if (user == null || !user.IsAdmin)
                {
                    context.Result = new ForbidResult();
                }
            }
            context.Result = new ForbidResult();
        }
    }
}
