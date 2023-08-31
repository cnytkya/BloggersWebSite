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
	public class BlogManager : IBlogService
	{
		IBlogyDal _blogDal;

		public BlogManager(IBlogyDal blogDal)
		{
			_blogDal = blogDal;
		}

		public List<Blog> GetList()
		{
			return _blogDal.GetListAll();
		}

		public List<Blog> GetLast3Blog()
		{
			return _blogDal.GetListAll().Take(3).ToList();

        }

		public Blog GetById(int id)
		{
			return _blogDal.GetById(id);
		}

		public List<Blog> GetBlogById(int id) 
		{ 
			return _blogDal.GetListAll(x=> x.BlogId == id);
		}

        public List<Blog> GetBlogsWithCategory()
        {
            return _blogDal.GetBlogsWithCategory();
        }

		public List<Blog> GetListWithCategoryByWriterBM(int id)
		{
			return _blogDal.GetListWithCategoryByWriter(id);

        }

		public List<Blog> GetBlogsListByWriter(int id)
		{
			return _blogDal.GetListAll(x=> x.WriterId == id);
		}

        public void Add(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void Delete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void Update(Blog t)
        {
            _blogDal.Update(t);
        }
    }
}
