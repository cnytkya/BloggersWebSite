using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IBlogyDal : IGenericDal<Blog>
	{
        List<Blog> GetBlogsWithCategory();
        List<Blog> GetListWithCategoryByWriter(int id);
    }
}
