using Newtonsoft.Json;
using SaaSProductsImport.DataAccess;
using SaaSProductsImport.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YamlDotNet.RepresentationModel;

namespace SaaSProductsImport.BusinessLogicLayer
{
    #region --class Info
    /*
     * 'ProductFileFormatParser' class implements 'IProductFileFormatParser' interface -> Includes -> 
     *      a. Functions for passing POCO 'ProductModel' to DataAccess for insert in table.
     *      b. Functions to parse file data into POCO object 'ProductModel' for as per file extension type -{.csv,.json} etc.
    */
    #endregion
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
         Function takes arguments productDetails : data of file as string ,
         *                          productSourceName: product source name ex- capterra
         * Map Json string content to productsModel object -> 
         *                      ProductsModel object passed to DataAccess object for database insert
         */
        #endregion
        public int InsertJsonProducts(string productDetails, string productName)
        {            
            ProductsModel products = new ProductsModel();
            //Add logic to parse json string into POCO object
            products.ProductName = productName;
            //Pass Products object to DataAccess for database insert
            var result = _productDataAccess.InsertProducts(products);
            return result;
        }


        #region --InsertCSVProducts -> functionInformation
        /*
         Function takes arguments productDetails : data of file as string ,
         *                          productSourceName: product source name ex- capterra
         * Map CSV string content to productsModel object -> 
         *                      ProductsModel object passed to DataAccess object for database insert model object is passed to DataAccess layer for database insert operations.      
         */
        #endregion

        public int InsertCSVProducts(string productDetails, string productName)
        {
            // Add logic for csv parser
            return 0;
        }

        #region --functionInformation
        /*
         * Function takes arguments productDetails : data of file as string ,
         *                          productSourceName: product source name ex- capterra
         * Map Yaml string content to productsModel object -> 
         *                      ProductsModel object passed to DataAccess object for database insert.     
        */
        #endregion
        public int InsertYamlProducts(string productDetails, string productSourceName)
        {
            //get products model object by parsing yaml string 
            var products = this.ParseYamltoProducts(productDetails, productSourceName);
            //pass parent prodcuts model for dataAccess insert operations 
            var result =  _productDataAccess.InsertProducts(products);
            return 0; 
        }

        //Function to parse yaml string to products model Class
        public ProductsModel ParseYamltoProducts(string productDetails, string productSourceName)
        {
            ProductsModel products = new ProductsModel();
            List<ProductDetailsModel> productLists = new List<ProductDetailsModel>();
            var input = new StringReader(productDetails);
            // Load the stream
            var yaml = new YamlStream();
            yaml.Load(input);
            // Examine the stream for product data
            for (int i = 0; i < 3; i++)
            {
                // Create mapping of keys and values from yaml string
                var mapping = (YamlMappingNode)yaml.Documents[0].RootNode[i];
                ProductDetailsModel product = new ProductDetailsModel();
                foreach (var entry in mapping.Children)
                {
                    // Assigns product name,categories,twitter for each product in file
                    switch (entry.Key.ToString().ToUpper())
                    {
                        case "TAGS":
                            product.Categories = entry.Value.ToString();
                            break;
                        case "NAME":
                            product.Name = entry.Value.ToString();
                            break;
                        case "TWITTER":
                            product.Twitter = entry.Value.ToString();
                            break;
                    }
                }
                Console.WriteLine("importing: Name: {0};Categories: {1};Twitter: {2}", product.Name, product.Categories, product.Twitter);
                productLists.Add(product);
            }

            //Add productName and lists of product to parent Model products
            products.ProductName = productSourceName;
            products.ProductsDetails = productLists;
            return products;

        }
    }
}
