﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
	public interface ICategoryService
	{
		void CategoryAdd(Category category);
		void CategoryDelete(Category category);
		void CategoryUpdate(Category category);
		
		List<Category> GetAllList();
		Category GetById(int id);
	}
}
