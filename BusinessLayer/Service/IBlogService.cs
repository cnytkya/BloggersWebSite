using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
	public interface IBlogService : IGenericService<Blog>
	{
		List<Blog> GetBlogsWithCategory();
		List<Blog> GetBlogsListByWriter(int id);
	}
}
