using MyMvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcProject.Business.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAllInbox(string receiverMail);
        List<Message> GetAllSendbox(string senderMail);
        Message GetById(int id);
        void Add(Message message);
        void Update(Message message);
        void Delete(Message message);
    }
}
