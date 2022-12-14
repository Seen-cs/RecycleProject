using Business.Concrete;
using DataAccess.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Sdk;


namespace TestProject
{
    [TestClass]
    public class CategoryManagerTest
    {
        [TestMethod]
        public void TestMethod()
        {
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
        }
        
        [TestMethod]
        public void TestingGetAll()
        {
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            var result = categoryManager.GetAll().Success;
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestingGetByCategoryId()
        {
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            var result = categoryManager.GetByCategoryId(1).Success;
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestingGetByCategoryName()
        {
            CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
            var result = categoryManager.GetByCategoryName("Kağıt").Success;
            Assert.AreEqual(true, result);
        }

    }
}
