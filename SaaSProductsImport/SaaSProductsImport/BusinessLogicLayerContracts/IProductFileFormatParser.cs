using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSProductsImport.BusinessLogicLayer
{
    /*
     *  -'IProductFileFormatParser' interface builds contract with 'ProductFileFormatParser' class.
     *  -Includes methods for parsing content of different file extensions into POCO model class.
     *  -Deserializing file content into ProductsModel object. 
    */
    public interface IProductFileFormatParser
    {
        // Method to Deserailize ,json string into Poco object and pass poco to DataAccess layer for database Insert
        public int InsertJsonProducts(string productDetails,string productName);
        // Method to Deserailize .CSV string into Poco object and pass poco to DataAccess layer for database Insert
        public int InsertCSVProducts(string productDetails, string productName);
        // Method to Deserailize .Yaml string into Poco object and pass poco to DataAccess layer for database Insert
        public int InsertYamlProducts(string productDetails, string productName);
        // Method to Parse Yaml File in Products 
        public ProductsModel ParseYamltoProducts(string productDetails, string productSourceName);
    }
}
