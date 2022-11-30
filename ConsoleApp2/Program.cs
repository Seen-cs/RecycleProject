using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EFProductDal());
            Product product = new Product();
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            var a= categoryManager.GetByCategoryName("Kağıt").Data.CategoryID;
            Console.WriteLine(a);
            product.ProductName = "vdsddvs";
            product.UnitPrice = 1;
           // productManager.Add(product);

            
        }
    }
}
