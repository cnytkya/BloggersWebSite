using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogyDal
    {
        public List<Blog> GetBlogsWithCategory()
        {
           using(var c=new AppDbContext())
            {
                return c.Blogs.Include(x=>x.Category).ToList();
            }
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var c = new AppDbContext())
            {
                return c.Blogs.Include(x => x.Category).Where(x => x.WriterId == id).ToList();
            }
        }
    }
}
