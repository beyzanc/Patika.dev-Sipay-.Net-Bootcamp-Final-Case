using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResiPay.Model.Mail;
using ResiPay.Service.Mail;
using System.Data;

namespace ResiPay.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class MailController : ControllerBase
    {
        private readonly IMailJobService mailJobService;

        public MailController(IMailJobService mailJobService)
        {
            this.mailJobService = mailJobService;

        }


        [HttpPost("sendReminders")]
        public IActionResult SendReminders()
        {
            var result = mailJobService.Send(new MailRequestModel());

            if (result.IsSuccess)
            {
                return Ok(result.Message);

            }
            else
            {
                return BadRequest(result.ErrorMessage);

            }

        }
    }
}
