using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SaaSProductsImport.BusinessLogicLayer;
using SaaSProductsImport.DataAccess;
using SaaSProductsImport.Model;
using System.Collections.Generic;

namespace SaaSProductsImportUnitTest
{
    [TestClass]
    public class FileReaderTests
    {
        
        [TestInitialize]
        public void InitializeTest()
        {
            
        }

        //Initialize dummy ProductsModel -> Model contains list of Products and Product Name
        public ProductsModel InitializeTestModel()
        {
            ProductsModel products = new ProductsModel();
            List<ProductDetailsModel> productsDetailsList = new List<ProductDetailsModel>();

            for (int i = 0; i < 3; i++)
            {
                ProductDetailsModel productModel = new ProductDetailsModel();
                productModel.Name = string.Format("Cars{0}", i);
                productModel.Categories = string.Format("Sidan{0}", i, i);
                productModel.Twitter = string.Format("twitter{0}", i);
                productsDetailsList.Add(productModel);
            }

            products.ProductName = "ABC";
            products.ProductsDetails = productsDetailsList;
            return products;
        }
        [TestMethod]
        public void ProductCountShouldMatchWithYaml()
        {
            //Mock IProductDataAccess and IProductFileFormatParser object
            var productFileDataAccess = new Mock<IProductDataAccess>();
            var productFileFormatParser = new Mock<IProductFileFormatParser>();
            
            //Initialize products model
            var products = InitializeTestModel();
            
            //Set expected product count
            int expected = 3;
            string productName = "BMW";

            //yaml string input
            string yaml = "---\n-\n  tags: \"Sidan0\"\n  name: \"Cars0\"\n  twitter: \"twitter0\"\n-\n  tags: \"Sidan1\"\n  name: \"Cars1\"\n  twitter: \"twitter1\"\n-\n  tags: \"Sidan2\"\n  name: \"Cars2\"\n  twitter: \"twitter2\"\n";
            
            //Setup Mock productFileFormatParser function
            productFileFormatParser.Setup(x => x.ParseYamltoProducts(yaml, productName)).Returns(products);

            //Initialize actual target object by passing Mock object in arguments 
            var actualProductFileParser = new ProductFileFormatParser(productFileDataAccess.Object);

            var actual = actualProductFileParser.ParseYamltoProducts(yaml, productName);
            //Assert actual products count read from yaml equals expected count
            Assert.AreEqual(expected, actual.ProductsDetails.Count);
        }

        //Test Method to validate dummy ProductName in productlist matches with actual productName
        [TestMethod]
        public void ProductNameShouldMatchWithYaml()
        {
            //Mock IProductDataAccess and IProductFileFormatParser object
            var productFileDataAccess = new Mock<IProductDataAccess>();
            var productFileFormatParser = new Mock<IProductFileFormatParser>();

            //Initialize products model
            var products = InitializeTestModel();            
            string productName = "BMW";

            //Set expected product name
            var expectedName = products.ProductsDetails[0].Name;

            //yaml string input
            string yaml = "---\n-\n  tags: \"Sidan0\"\n  name: \"Cars0\"\n  twitter: \"twitter0\"\n-\n  tags: \"Sidan1\"\n  name: \"Cars1\"\n  twitter: \"twitter1\"\n-\n  tags: \"Sidan2\"\n  name: \"Cars2\"\n  twitter: \"twitter2\"\n";
           
            //Setup Mock productFileFormatParser function
            productFileFormatParser.Setup(x => x.ParseYamltoProducts(yaml, productName)).Returns(products);
            
            //Initialize actual target object by passing Mock object in arguments 
            var actualProductFileParser = new ProductFileFormatParser(productFileDataAccess.Object);
            
            //Get actual products from actual execution of test target method
            var actualProduct = actualProductFileParser.ParseYamltoProducts(yaml, productName);
            var actualName = actualProduct.ProductsDetails[0].Name;
            
            //Asset actual products name read from yaml equals expected name
            Assert.AreEqual(expectedName, actualName);
        }
    }
}
