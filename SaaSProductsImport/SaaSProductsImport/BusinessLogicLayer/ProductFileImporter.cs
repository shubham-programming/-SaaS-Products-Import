using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SaaSProductsImport.BusinessLogicLayer
{
    /*
     * 'ProductFileImporter' class implements 'IProductFileImporter' interface . This class perform following functions --
     *      a. Includes methods for importing files in accordance of fileSource - .csv, .json 
    */
    public class ProductFileImporter : IProductImporter
    {
        // IProductFileReader object retrieved through dependency Injection
        private IProductFileReader _FileReader;       
        public ProductFileImporter(IProductFileReader fileReader )
        {            
            _FileReader = Startup.serviceProvider.BuildServiceProvider().GetService<IProductFileReader>(); ;
        }

        /*
         * Function to check file source is folder/url/ , then reads files according to source .
         * Ex - If source is folder then file is read from folder and not url source .
         * Function accepts List of 'ProductImportConfiguration' class object which is POCO class mapping of product details keys present in appsettings.json 
        */
        public void ImportFile(List<ProductImportConfiguration> productImportConfigurations)
        {            
            foreach (ProductImportConfiguration importConfig in productImportConfigurations)
            {
                if (!String.IsNullOrEmpty(importConfig.productsConfiguration.ProductFolderPath))
                {
                    foreach (string file in importConfig.productsConfiguration.ProductFiles)
                    {
                        var fileCompletePath = Path.Combine(importConfig.productsConfiguration.ProductFolderPath, file);
                        _FileReader.ReadFilesFromFolder(fileCompletePath,file, importConfig.productsConfiguration.ImportOnDayOfWeek);
                    }
                }
                else if (!String.IsNullOrEmpty(importConfig.productsConfiguration.ProductDownloadUrl))
                {
                    foreach (string file in importConfig.productsConfiguration.ProductFiles)
                    {
                        _FileReader.ReadFilesFromURL(importConfig.productsConfiguration.ProductDownloadUrl, file, importConfig.productsConfiguration.ImportOnDayOfWeek);
                    }
                }
            }
        }

        public bool CheckFolderExists(string path)
        {            
            if (Directory.Exists(path))
            {
                return true;
            }
            return false;
        }


    }
}
