using Microsoft.AspNetCore.Http;
using ResiPay.Service.Token;
using ResiPay.Service.User;
using System.Linq;
using System.Threading.Tasks;

namespace ResiPay.API.Infrastructure;

public class JwtMiddleware
        {
       
            private readonly RequestDelegate next;

            public JwtMiddleware(RequestDelegate _next)
            {
                next = _next;
            }

            public async Task Invoke(HttpContext context, IUserService userService, ITokenService tokenService)
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var userId = tokenService.ValidateToken(token);
                if ( userId != null)
                {
                    context.Items["User"] = userService.GetById(userId.Value).Entity;


                    context.Items["IsAdmin"] = ((ResiPay.Model.User.UserViewModel)context.Items["User"]).IsAdmin;
                }

                await next(context);

            }

   
        }
    

