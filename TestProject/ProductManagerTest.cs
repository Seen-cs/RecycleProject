using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;

namespace TestProject
{
    [TestClass]
    public class ProductManagerTest
    {
        [TestMethod]
        public void TestMethod()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());
        }

        [TestMethod]
        public void TestingAdd()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());
            Product product = new Product();
            product.ProductName = "emre";
            product.CategoryID = 3;
            product.UnitPrice = 9;
            var result = productManager.Add(product).Success;
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestingGetAll()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());
            var result = productManager.GetlAll().Success;
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestingGetByCategory()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());
            var result = productManager.GetByCategory(1).Success;
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestingUpdate()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());
            Product product = new Product();
            product.ProductID = 1016;
            product.ProductName = "b";
            product.CategoryID = 3;
            product.UnitPrice = 8;
            var result = productManager.UpDate(product).Success;
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestingDelete()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());
            Product product = new Product();
            product.ProductID = 1022;
            var result = productManager.Remove(product).Success;
            Assert.AreEqual(true, result);
        }
    }
}
