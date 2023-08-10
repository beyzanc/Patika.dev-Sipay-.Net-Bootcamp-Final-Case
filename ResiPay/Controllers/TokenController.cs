using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ResiPay.Model.Token;
using ResiPay.Service.Token;
using ResiPay.Service.User;

namespace ResiPay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;

        public LoginController(IUserService userService, ITokenService tokenService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.tokenService = tokenService;

        }

        [HttpPost]
        public IActionResult Login(TokenRequestModel tokenRequest) {

            var tokenResponse = tokenService.GenerateToken(tokenRequest);

            if (tokenResponse.IsSuccess)
            {
                return Ok(tokenResponse);
            }
            else
            {
                return BadRequest(tokenResponse.Message);
            }
        }

    }
}
