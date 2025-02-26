using Enums.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebStoryFroEveryting.Services;

namespace WebStoryFroEveryting.Controllers.CustomAutorizeAttributes
{
    public class HasPermissionAttribute : ActionFilterAttribute
    {
        private AuthService _authService;
        private Permisson _requiredPermisson;

        public HasPermissionAttribute(Permisson requiredPermisson)
        {
            _requiredPermisson = requiredPermisson;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _authService = context
                .HttpContext
                .RequestServices
                .GetRequiredService<AuthService>();

            if (!_authService.HasPermission(_requiredPermisson))
            {
                context.Result = new ForbidResult();
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
