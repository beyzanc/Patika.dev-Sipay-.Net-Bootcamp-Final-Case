using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ResiPay.Model.BaseModel;
using ResiPay.Model.Message;
using ResiPay.Service.Message;

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
        public Base<MessageViewModel> GetMessages()
        {
            return messageService.GetMessages();
        }

        [HttpGet("GetByReceiver/{id}")]
        public Base<MessageViewModel> GetMessagesByReceiver(int id)
        {
            return messageService.GetMessagesByReceiver(id);
        }

        [HttpGet("GetBySender/{id}")]
        public Base<MessageViewModel> GetMessagesBySender(int id)
        {
            return messageService.GetMessagesBySender(id);
        }

        [HttpPost]
        public Base<MessageViewModel> SendMessage(MessageInsertModel messageInsert)
        {
            return messageService.SendMessage(messageInsert);
        }

        [HttpPut]
        public Base<MessageViewModel> UpdateMessage(MessageUpdateModel messageUpdate)
        {
            return messageService.UpdateMessage(messageUpdate);
        }

        [HttpDelete]
        public Base<MessageViewModel> DeleteMessage(int id)
        {
            return messageService.DeleteMessage(id);
        }

        [HttpPut("Read")]
        public Base<MessageViewModel> ReadMessage(int messageId)
        {
            return messageService.ReadMessage(messageId);
        }

    }
}
