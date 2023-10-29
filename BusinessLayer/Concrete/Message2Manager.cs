using BusinessLayer.Service;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _m2;

        public Message2Manager(IMessage2Dal m2)
        {
            _m2 = m2;
        }

        public void Add(Message2 t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Message2 t)
        {
            throw new NotImplementedException();
        }

        public Message2 GetById(int id)
        {
            return _m2.GetById(id);
        }

        public List<Message2> GetInboxListByWriter(int id)
        {
            return _m2.GetListWithMessageByWriter(id);
        }

        public List<Message2> GetList()
        {
           return _m2.GetListAll();
        }

        public void Update(Message2 t)
        {
            throw new NotImplementedException();
        }
    }
}
