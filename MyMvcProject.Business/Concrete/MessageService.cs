using MyMvcProject.Business.Abstract;
using MyMvcProject.DataAccess.Abstract;
using MyMvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcProject.Business.Concrete
{
    public class MessageService : IMessageService
    {
        private IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public void Add(Message message)
        {
            _messageRepository.Add(message);
        }

        public void Delete(Message message)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetAllInbox(string receiverMail)
        {
            return _messageRepository.GetAll(message => message.ReceiverMail == receiverMail);
        }

        public List<Message> GetAllSendbox(string senderMail)
        {
            return _messageRepository.GetAll(message => message.SenderMail == senderMail);
        }

        public Message GetById(int id)
        {
            return _messageRepository.Get(message=>message.MessageId == id);
        }

        public void Update(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
