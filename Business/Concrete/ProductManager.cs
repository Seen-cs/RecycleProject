using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Contants;
using Business.ValitadionRules.FluentValitadion;
using Core.Aspect.Autofac.Validation;
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
        
        [ValidationAspect(typeof(ProductValidator))]
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
        public IDataResult<List<Product>> GetByCategory(int Id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryID == Id));
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
