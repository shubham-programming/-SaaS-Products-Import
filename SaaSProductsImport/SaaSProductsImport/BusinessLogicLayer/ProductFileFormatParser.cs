using Newtonsoft.Json;
using SaaSProductsImport.DataAccess;
using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSProductsImport.BusinessLogicLayer
{
    public class ProductFileFormatParser : IProductFileFormatParser
    {
        IProductDataAccess _productDataAccess;

        public ProductFileFormatParser(IProductDataAccess productDataAccess)
        {
            _productDataAccess = productDataAccess;
        }
        public int InsertJsonProducts(string productDetails,string productName)
        {
            /*
             * This function accepts ProductFile model as parameter
             * This function performs following logic -
             *          1. Parse Json string to product
             * 
             */
            ProductsModel products = new ProductsModel();
            ProductDetailsModel [] productDetail = JsonConvert.DeserializeObject<ProductDetailsModel []>(productDetails);
            products.ProductName = productName;            
            var result = _productDataAccess.InsertProducts(products);
            return result;
        }
        public int InsertCSVProducts(string productDetails , string productName)
        {

            return 0;
        }
        public int InsertYamlProducts(string productDetails, string productName)
        {
            return 0; 
        }

    }
}
