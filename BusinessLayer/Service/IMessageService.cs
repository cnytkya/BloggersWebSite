using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Service
{
    public interface IMessageService : IGenericService<Message>
    {
        List<Message> GetListByMessageId(int id);
    }
}
