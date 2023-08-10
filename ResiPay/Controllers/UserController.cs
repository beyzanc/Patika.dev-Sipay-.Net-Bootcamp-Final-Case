using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResiPay.Model.BaseModel;
using ResiPay.Model.User;
using ResiPay.Service.User;
using System.Data;

namespace ResiPay.API.Controllers
{

    [Route("api/[controller]s")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {

        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
                 
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
