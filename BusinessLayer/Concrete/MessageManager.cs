using BusinessLayer.Service;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _message;

        public MessageManager(IMessageDal message)
        {
            _message = message;
        }

        public void Add(Message t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Message t)
        {
            throw new NotImplementedException();
        }

        public Message GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetListByMessageId(int id)
        {
            return _message.GetListAll(x=>x.MessageId == id);
        }

        public List<Message> GetList()
        {
            return _message.GetListAll();
        }

        public void Update(Message t)
        {
            throw new NotImplementedException();
        }
    }
}
