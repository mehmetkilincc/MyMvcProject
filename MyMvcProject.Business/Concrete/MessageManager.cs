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
    public class MessageManager : IMessageService
    {
        private IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Add(message);
        }

        public void Delete(Message message)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetAllInbox(string receiverMail)
        {
            return _messageDal.GetAll(message => message.ReceiverMail == receiverMail);
        }

        public List<Message> GetAllSendbox(string senderMail)
        {
            return _messageDal.GetAll(message => message.SenderMail == senderMail);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(message=>message.MessageId == id);
        }

        public void Update(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
