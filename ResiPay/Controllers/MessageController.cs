using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResiPay.Model.BaseModel;
using ResiPay.Model.Message;
using ResiPay.Service.Message;
using System.Data;

namespace ResiPay.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly IMessageService messageService;
        private readonly IMapper mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            this.messageService = messageService;
            this.mapper = mapper;

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public Base<MessageViewModel> GetMessages()
        {
            return messageService.GetMessages();

        }

        [HttpGet("GetByReceiver/{id}")]
        [Authorize(Roles = "Admin, Resident")]
        public Base<MessageViewModel> GetMessagesByReceiver(int id)
        {
            return messageService.GetMessagesByReceiver(id);

        }

        [HttpGet("GetBySender/{id}")]
        [Authorize(Roles = "Admin")]
        public Base<MessageViewModel> GetMessagesBySender(int id)
        {
            return messageService.GetMessagesBySender(id);

        }

        [HttpPost]
        [Authorize(Roles = "Admin, Resident")]
        public Base<MessageViewModel> SendMessage(MessageInsertModel messageInsert)
        {
            return messageService.SendMessage(messageInsert);

        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public Base<MessageViewModel> UpdateMessage(MessageUpdateModel messageUpdate)
        {
            return messageService.UpdateMessage(messageUpdate);

        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public Base<MessageViewModel> DeleteMessage(int id)
        {
            return messageService.DeleteMessage(id);

        }

        [HttpPut("Read")]
        [Authorize(Roles = "Admin")]
        public Base<MessageViewModel> ReadMessage(int messageId)
        {
            return messageService.ReadMessage(messageId);

        }

    }
}
