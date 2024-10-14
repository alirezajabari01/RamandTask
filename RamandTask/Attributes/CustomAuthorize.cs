using Application.Security;
using Application.UserFilters;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RamandTask.Attributes;

public class CustomAuthorize : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
        var token = context.HttpContext.Request.Headers["Authorization"].ToString();
        if (!string.IsNullOrEmpty(token))
        {
            var claimPrinciple = TokenGenerator.ValidateToken(token);
            if (claimPrinciple != null)
            {
                var userContext =
                    (IUserContext)context.HttpContext.RequestServices.GetService(typeof(IUserContext));
                
                var userId = claimPrinciple.Claims.FirstOrDefault(x => x.Type == "userid")?.Value;
                var userName = claimPrinciple.Claims.FirstOrDefault(x => x.Type == "userName")?.Value;
                
                userContext.UserId = int.Parse(userId);
                userContext.UserName = userName;
            }
        }
        else
        {
            throw new UnauthorizedAccessException("Invalid token");
        }
    }
}