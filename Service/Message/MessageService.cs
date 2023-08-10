using AutoMapper;
using ResiPay.DB;
using ResiPay.Model.BaseModel;
using ResiPay.Model.Message;
using ResiPay.Service.User;
using ResiPay.Service.Validations.Message;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResiPay.Service.Message
{
    public class MessageService : IMessageService
    {
        private readonly IMapper mapper;
        private readonly MessageInsertValidator validator;
        private readonly ResiPayDbContext dbContext;
        private readonly IUserService userService;

        public MessageService(IMapper mapper, MessageInsertValidator validator, ResiPayDbContext dbContext, IUserService userService)
        {
            this.mapper = mapper;
            this.validator = validator;
            this.dbContext = dbContext;
            this.userService = userService;

        }

        public Base<MessageViewModel> GetMessages()
        {
            var result = new Base<MessageViewModel>();

            var messages = dbContext.Message
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.InsertDate)
                .ThenBy(x => x.IsRead);


            if (messages.Any())
            {
                result.List = mapper.Map<List<MessageViewModel>>(messages);
                result.IsSuccess = true;
                result.OkMessage = "All messages are listed.";
                result.TotalCount = messages.Count();

            }
            else
            {
                result.IsSuccess = false;
                result.ExceptionMessage = "No messages found.";

            }

            dbContext.SaveChanges();
            return result;

        }


        public Base<MessageViewModel> GetMessagesByReceiver(int id)
        {
            var result = new Base<MessageViewModel>();

            var messages = dbContext.Message
                .Where(x => x.ReceiverId == id && !x.IsDeleted)
                .OrderByDescending(x => x.InsertDate)
                .ThenBy(x => x.IsRead);

            if (messages.Any())
            {
                result.List = mapper.Map<List<MessageViewModel>>(messages);
                result.IsSuccess = true;
                result.OkMessage = "Messages are listed.";
                result.TotalCount = messages.Count();

            }
            else
            {
                result.IsSuccess = false;
                result.ExceptionMessage = "No messages found.";

            }

            dbContext.SaveChanges();
            return result;

        }


        public Base<MessageViewModel> GetMessagesBySender(int id)
        {
            var result = new Base<MessageViewModel>();

            var messages = dbContext.Message
                .Where(x => x.UserId == id && !x.IsDeleted)
                .OrderByDescending(x => x.InsertDate)
                .ThenBy(x => x.IsRead);

            if (messages.Any())
            {
                result.List = mapper.Map<List<MessageViewModel>>(messages);
                result.IsSuccess = true;
                result.OkMessage = "Messages are listed.";
                result.TotalCount = messages.Count();

            }
            else
            {
                result.IsSuccess = false;
                result.ExceptionMessage = "No messages found.";

            }

            dbContext.SaveChanges();
            return result;

        }

        public Base<MessageViewModel> SendMessage (MessageInsertModel messageInsert)
        {
            var result = new Base<MessageViewModel>();

            var sender = dbContext.User
                .SingleOrDefault(x => x.Id  == messageInsert.UserId);

            var receiver = dbContext.User
                .SingleOrDefault(x => x.Id == messageInsert.ReceiverId);

            if (sender == null)
            {
                result.ExceptionMessage = "Sender ID is not found!";
                result.IsSuccess = false;
                return result;

            }

            if (receiver == null)
            {
                result.ExceptionMessage = "Receiver ID is not found!";
                result.IsSuccess = false;
                return result;

            }

            if (sender.Status == "Resident" && receiver.Status != "Admin")
            {
                result.ExceptionMessage = "Residents can only send messages to administrators.";
                result.IsSuccess = false;
                return result;

            }

            var model = mapper.Map<ResiPay.DB.Entities.Message>(messageInsert);

            model.ReceiverName = receiver.Name;
            model.ReceiverSurname = receiver.Surname;
            model.SenderName = sender.Name;
            model.SenderSurname = sender.Surname;
            model.InsertDate = DateTime.Now;

            dbContext.Message.Add(model);
            dbContext.SaveChanges();

            result.Entity = mapper.Map<MessageViewModel>(model);
            result.IsSuccess = true;
            result.OkMessage = "Message is added successfully.";

            return result;

        }

        public Base<MessageViewModel> UpdateMessage (MessageUpdateModel messageUpdate)
        {

            var result = new Base<MessageViewModel>();

            var model = dbContext.Message
                .SingleOrDefault(x => x.Id == messageUpdate.Id);

            if (model != null) {

                model.Subject = messageUpdate.Subject;
                model.Content = messageUpdate.Content;

                dbContext.SaveChanges();

                result.Entity = mapper.Map<MessageViewModel>(model);
                result.OkMessage = "Message is updated successfully.";
                result.IsSuccess = true;

            }
            else
            {
                result.ExceptionMessage = "Message is not found to update.";
                result.IsSuccess = false;

            }

            return result;

        }

        public Base<MessageViewModel> DeleteMessage(int id)
        {
            var result = new Base<MessageViewModel>();

            var message = dbContext.Message
                .SingleOrDefault(x => x.Id == id && !x.IsDeleted);

            if (message != null)
            {
                message.IsDeleted = true;

                dbContext.SaveChanges();

                result.IsSuccess = true;
                result.OkMessage = "Message is deleted successfully.";

            }
            else
            {
                result.ExceptionMessage = "Message is not found or already deleted.";
                result.IsSuccess = false;

            }

            return result;

        }

        public Base<MessageViewModel> ReadMessage(int messageId)
        {
            var result = new Base<MessageViewModel>();

            var message = dbContext.Message
                .SingleOrDefault(x => x.Id == messageId && !x.IsDeleted);

            if (message != null)
            {
                message.IsRead = true;
                message.UpdateDate = DateTime.Now;
                dbContext.SaveChanges();

                result.Entity = mapper.Map<MessageViewModel>(message);
                result.IsSuccess = true;
                result.OkMessage = "Message is marked as read.";

            }
            else
            {
                result.ExceptionMessage = "Message is not found or already deleted.";
                result.IsSuccess = false;

            }

            return result;

        }
    }
}
