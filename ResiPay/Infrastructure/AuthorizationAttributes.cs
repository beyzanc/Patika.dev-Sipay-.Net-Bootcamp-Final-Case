using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ResiPay.API.Infrastructure
{
    public class AuthorizationAttributes
    {
        [AttributeUsage(AttributeTargets.Method)]
        public class AdminAttribute : Attribute
        { }

        [AttributeUsage(AttributeTargets.Method)]
        public class AllowAnonymousAttribute : Attribute
        { }

        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class AuthorizeAttribute : Attribute, IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
                if (allowAnonymous)
                    return;

                var user = context.HttpContext.Items["User"];
                if (user == null)
                {
                    context.Result = new JsonResult (new { message = "Unauthorized" }) 
                    { 
                        StatusCode = StatusCodes.Status401Unauthorized
                    };
                    return;
                }

                var allowAdmin = context.ActionDescriptor.EndpointMetadata.OfType<AdminAttribute>().Any();
                if (allowAdmin)
                {
                    bool isAdmin = (bool)context.HttpContext.Items["IsAdmin"];
                    if (!isAdmin)
                        context.Result = new JsonResult(new { message = "Unauthorized" })
                        {
                            StatusCode = StatusCodes.Status401Unauthorized
                        };
                }
            }
        }
    }
}
