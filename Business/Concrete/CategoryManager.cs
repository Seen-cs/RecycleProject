﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll().ToList());
        }

        public IDataResult<Category> GetByCategoryId(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(p => p.CategoryID == id));
        }

        public IDataResult<Category> GetByCategoryName(string categoryName)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(p => p.CategoryName == categoryName));
        }
    }
}
