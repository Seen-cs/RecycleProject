﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<Category> GetByCategoryName(string categoryName);
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetByCategoryId(int id);


    }
}
