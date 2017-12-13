using StudLine.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using StudLine.UnitOW;

namespace StudLine.Services
{
    public class MessageService : BaseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MessageService(IUnitOfWork unitOfWork, HttpContextBase httpContext)
            : base(httpContext)
        {
            _unitOfWork = unitOfWork;
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

            _unitOfWork.MessageRepository.Add(message);
            _unitOfWork.SaveChanges();
        }

        // Messages by group
        public IEnumerable<Message> GetLastMessages(int count, string groupName)
        {
            return _unitOfWork.MessageRepository.GetLastMessages(count, groupName).OrderBy(x => x.ReceiveTime).ToList();
        }
    }
}