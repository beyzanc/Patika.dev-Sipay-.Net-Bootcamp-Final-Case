using ResiPay.Model.BaseModel;
using ResiPay.Model.Message;

namespace ResiPay.Service.Message
{
    public interface IMessageService
    {
        public Base<MessageViewModel> GetMessages();
        public Base<MessageViewModel> GetMessagesByReceiver(int id);
        public Base<MessageViewModel> GetMessagesBySender(int id);
        public Base<MessageViewModel> SendMessage(MessageInsertModel messageInsert);
        public Base<MessageViewModel> UpdateMessage(MessageUpdateModel messageUpdate);
        public Base<MessageViewModel> DeleteMessage(int id);
        public Base<MessageViewModel> ReadMessage(int messageId);

    }
}
