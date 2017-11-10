using RCodingSchool.Models;
using System;
using RCodingSchool.Interfaces;
using System.Collections.Generic;
using System.Web;
using System.Linq;

namespace RCodingSchool.Services
{
    public class MessageService : BaseService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository, HttpContextBase httpContext)
            : base(httpContext)
        {
            _messageRepository = messageRepository;
        }

        //Group message
        public void SaveMessage(string messageText, DateTime date)
        {
            var message = new Message
            {
                Text = messageText,
                UserId = UserId,
                ReceiveTime = date,
                GroupName = GroupName
            };

            _messageRepository.Add(message);
            _messageRepository.SaveChanges();
        }

        // Messages by group
        public IEnumerable<Message> GetLastMessages(int count)
        {
            return _messageRepository.GetLastMessages(count).Where(x => x.GroupName == GroupName).ToList();
        }
    }
}