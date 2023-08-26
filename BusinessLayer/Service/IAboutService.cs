using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Service
{
	public interface IAboutService 
	{
		List<About> GetList();
	}
}
