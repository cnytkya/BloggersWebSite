using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IBlogyDal : IGenericDal<Blog>
	{
        List<Blog> GetBlogsWithCategory();
        List<Blog> GetListWithCategoryByWriter(int id);
    }
}
