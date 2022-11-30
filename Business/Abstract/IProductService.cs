using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult Add(Product product);
        IResult Remove(Product product);
        IResult UpDate(Product product);
        IDataResult<Product> GetById(int Id);
        IDataResult <List<Product>> GetlAll();

    }
}
