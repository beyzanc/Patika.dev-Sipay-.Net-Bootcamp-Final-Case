using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ResiPay.Model.BaseModel;
using ResiPay.Model.User;
using ResiPay.Service.Token;
using ResiPay.Service.User;

namespace ResiPay.API.Controllers
{

    // [Infrastructure.AuthorizationAttributes.Authorize]
    [Route("api/[controller]s")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly ITokenService tokenService;

        public UserController(IUserService userService, IMapper mapper, ITokenService tokenService)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.tokenService = tokenService;
                 
        }

        // [Infrastructure.AuthorizationAttributes.AllowAnonymous]
        [HttpPost("login")]
        public Base<UserLoginResponseModel> Login(UserLoginRequestModel loginRequest)
        {
            return userService.Login(loginRequest);
        }


        [HttpGet]
        public Base<UserViewModel> GetAllUser()
        {
            return userService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public Base<UserViewModel> GetById(int id)
        {
            return userService.GetById(id);
        }


        [HttpDelete("{id}")]
        public Base<UserViewModel> Delete(int id)
        {
            return userService.Delete(id);
        }

        // [Infrastructure.AuthorizationAttributes.AllowAnonymous]
        [HttpPost("register")]
        public Base<UserViewModel> Insert(UserInsertModel newInsert)
        {
            return userService.Insert(newInsert);
        }

        [HttpPut("{id}")]
        public Base<UserViewModel> Update ([FromBody] UserInsertModel user, int id)
        {
            return userService.Update(user, id);
        }

    }
}
