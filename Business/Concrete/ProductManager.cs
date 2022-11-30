using Business.Abstract;
using Business.Contants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager:IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public IResult Add(Product product)
        {
            var result = BusinessRules.Run(CheckIfProductNameOfExists(product.ProductName));
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult();
        }
        public IDataResult<List<Product>> GetlAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll().ToList());
        }

        public IResult Remove(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult();
        }

        public IResult UpDate(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult();
        }

        public IDataResult<Product> GetById(int Id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.CategoryID == Id));
        }

        private IResult CheckIfProductNameOfExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameOfExists);
            }
            return new SuccessResult();
        }

        

       
    }
}
