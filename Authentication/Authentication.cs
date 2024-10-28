using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace ProductManagement2.Authentication
{
	public class AuthenticationAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if (context.HttpContext.Session.GetString("Username") == null)
			{
				context.Result = new RedirectToRouteResult(new RouteValueDictionary
				{
					{ "controller", "Access" },
					{ "action", "Login" }
				});
			}
		}
	}
}
