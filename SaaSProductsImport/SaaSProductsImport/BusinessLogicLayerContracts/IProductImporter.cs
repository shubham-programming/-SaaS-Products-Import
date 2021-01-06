using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSProductsImport.BusinessLogicLayer
{
    public interface IProductImporter
    {
        /*
         * 'IProductImporter' interface builds contract with 'ProductImporter' class  -
         *  Functions for determining if file should be read from folder/url or any other source.
         *  Calls 'IProductFileReader' for performing read operation on file as per file source -> folder/url. 
        */

        //Function to import file from Product Import sources for fileInput 
        public void ImportFile(IList<ProductImportConfiguration> productImportConfigurations);
        //Function to check if folder exists at product folder location specified by appsettings.json 
        public bool CheckFolderExists(string path);
    }
}
