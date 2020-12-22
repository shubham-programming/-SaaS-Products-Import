using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSProductsImport.BusinessLogicLayer
{
    public interface IProductImporter
    {
        /*
         * 'IProductImporter' interface builds contract with 'ProductImporter' class for following actions/features -
         *      a. Includes methods for determining if file should be read from folder/url or any other source.
         *      b. Calls 'IProductFileReader' for performing read operation on file as per file source -> folder/url. 
        */

        //Function to import file from folder or url or any source based on fileInput configuration Poco object {'ProductsConfiguration'} read from appsettings.json.
        public void ImportFile(List<ProductImportConfiguration> productImportConfigurations);
        //Function to check if folder exists at product folder location specified by appsettings.json 
        public bool CheckFolderExists(string path);
    }
}
