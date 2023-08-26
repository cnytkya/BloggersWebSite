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
	public class AboutManager : IAboutService
	{
		IAboutDal _dal;

		public AboutManager(IAboutDal dal)
		{
			_dal = dal;
		}

		public List<About> GetList()
		{
			return _dal.GetListAll();
		}
	}
}
