using Newtonsoft.Json;
using SaaSProductsImport.DataAccess;
using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSProductsImport.BusinessLogicLayer
{
    /*
     * 'ProductFileFormatParser' class implements 'IProductFileFormatParser' interface . This class perform following functions --
     *      a. Includes methods for passing POCO 'ProductModel' details to dataAccess layer for database insert.
     *      b. Contains functions to parse file content fetched from 'IProductFileReader' into POCO object 'ProductModel' for different file extensions - .csv , .json etc.
    */
    public class ProductFileFormatParser : IProductFileFormatParser
    {
        // Property to assign dataAccess layer object through Dependency Injection
        IProductDataAccess _productDataAccess;

        public ProductFileFormatParser(IProductDataAccess productDataAccess)
        {
            _productDataAccess = productDataAccess;
        }

        #region --InsertJsonProducts -> functionInformation 
        /*
         * This function accepts productDetails -> content of file in string format , productName -> product Name ex- capterra 
         * This function performs following logic -
         *          1. Parse Json string to productsModel object -> Products model object is passed to DataAccess layer for db insert.
         */
        #endregion
        public int InsertJsonProducts(string productDetails, string productName)
        {            
            ProductsModel products = new ProductsModel();
            ProductDetailsModel[] productDetail = JsonConvert.DeserializeObject<ProductDetailsModel[]>(productDetails);
            products.ProductName = productName;
            var result = _productDataAccess.InsertProducts(products);
            return result;
        }


        #region --InsertCSVProducts -> functionInformation
        /*
         * This function accepts productDetails -> content of file in string format , productName -> product Name ex- capterra 
         * This function performs following logic -
         *          1. Parse CSV string content of file to productsModel object -> Products model object is passed to DataAccess layer for database insert operations.      
         */
        #endregion

        public int InsertCSVProducts(string productDetails, string productName)
        {

            return 0;
        }

        #region --functionInformation
        /*
         * This function accepts productDetails -> content of file in string format , productName -> product Name ex- capterra 
         * This function performs following logic -
         *          1. Parse Yaml string content of file to productsModel object -> Products model object is passed to DataAccess layer for database insert operations.      
        */
        #endregion
        public int InsertYamlProducts(string productDetails, string productName)
        {
            return 0;
        }

    }
}
