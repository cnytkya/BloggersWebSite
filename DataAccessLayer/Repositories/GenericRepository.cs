using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
	public class GenericRepository<T> : IGenericDal<T> where T : class
	{
		public void Delete(T item)
		{
			using var c = new AppDbContext();
			c.Remove(item);
			c.SaveChanges();
		}

		public T GetById(int id)
		{
			using var c = new AppDbContext();
			return c.Set<T>().Find(id); 
		}

		public List<T> GetListAll()
		{
			using var c = new AppDbContext();
			return c.Set<T>().ToList();
		}

		public void Insert(T item)
		{
			using var c = new AppDbContext();
			c.Add(item);
			c.SaveChanges();
		}

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            using var c = new AppDbContext();
            return c.Set<T>().Where(filter).ToList();
        }

        public void Update(T item)
		{
			using var c = new AppDbContext();
			c.Update(item);
			c.SaveChanges();
		}
	}
}
