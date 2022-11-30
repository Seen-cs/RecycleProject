using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EFProductDal:EfEntityRepositoryBase<Product,RecyleContex>,IProductDal 
    {
        public List<ProductDetailDto> GetProductDetailDtos()
        {
            using (RecyleContex contex = new RecyleContex())
            {
                var result = from p in contex.Products
                             join c in contex.Categories
                             on p.CategoryID equals c.CategoryID
                             select new ProductDetailDto
                             {
                                 ProductID = p.ProductID,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitPrice = p.UnitPrice
                             };
                return result.ToList();

            }
        }
    }
}
