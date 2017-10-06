using RCodingSchool.Models;
using RCodingSchool.Repository;
using System;
using System.Collections.Generic;

namespace RCodingSchool.Services
{
	public class MessageService
	{
		private readonly IMessageRepository _messageRepository;
		private readonly IMessageGroupRepository _messageGroupRepository;

		public MessageService(IMessageRepository messageRepository, IMessageGroupRepository messageGroupRepository)
		{
			_messageRepository = messageRepository;
			_messageGroupRepository = messageGroupRepository;
		}

		//Private message
		public void SaveMessage(string messageText, User userFrom, User userTo, DateTime date)
		{
			if (!(String.IsNullOrEmpty(messageText) || userFrom == null || userTo == null))
			{
				Message message = new Message();
				message.User = userFrom;
				message.Text = messageText;
				_messageRepository.Add(message);
			}
		}

		//Group message
		public void SaveMessage(string messageText, MessageGroup messageGroup, User userFrom, DateTime date)
		{
			if (!(String.IsNullOrEmpty(messageText) || userFrom == null))
			{
				Message message = new Message();
				if (_messageGroupRepository.Get(messageGroup.Id) == null)
				{
					_messageGroupRepository.Add(messageGroup);
				}
				message.User = userFrom;
				message.Text = messageText;
				_messageRepository.Add(message);
			}
		}

		//To All message
		public void SaveMessage(string messageText, User userFrom, DateTime date)
		{
			if (!(String.IsNullOrEmpty(messageText) || userFrom == null))
			{
				Message message = new Message();
				//General group by default
				message.User = userFrom;
				message.Text = messageText;
				_messageRepository.Add(message);
			}
		}
	}
}