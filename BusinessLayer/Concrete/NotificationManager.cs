using BusinessLayer.Service;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        //AppDbContext _appDbContext;

        //public NotificationManager(AppDbContext appDbContext)
        //{
        //    _appDbContext = appDbContext;
        //}

        INotificationDal _ndal;

        public NotificationManager(INotificationDal ndal)
        {
            _ndal = ndal;
        }

        public void Add(Notification t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Notification t)
        {
            throw new NotImplementedException();

        }

        public Notification GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Notification> GetList()
        {
            return _ndal.GetListAll();
        }

        public void Update(Notification t)
        {
            throw new NotImplementedException();
        }
    }
}
