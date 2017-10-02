using RCodingSchool.Repository;

namespace RCodingSchool.Services
{
    public class MessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public void SaveMessage(object message)
        {
            // Sending message logic
        }
    }
}