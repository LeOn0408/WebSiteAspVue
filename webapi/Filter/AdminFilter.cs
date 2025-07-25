using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using webapi.Model.Entities;

namespace webapi.Filter
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AdminFilter : Attribute,IAuthorizationFilter
    {
        private readonly DataContext _applicationContext;

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
                UserEntity? user = _applicationContext.Users.FirstOrDefault(x => x.Id == token.User.Id);
                if (user == null || !user.IsAdmin)
                {
                    context.Result = new ForbidResult();
                }
            }
            context.Result = new ForbidResult();
        }
    }
}
