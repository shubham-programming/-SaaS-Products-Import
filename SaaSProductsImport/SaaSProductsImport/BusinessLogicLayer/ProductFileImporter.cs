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
     * 'ProductFileImporter' class implements 'IProductFileImporter' interface.-
     *  Includes functions for importing files in accordance of fileSource - .csv, .json 
    */
    public class ProductFileImporter : IProductImporter
    {
        // IProductFileReader object initialized through dependency Injection
        private IProductFileReader _FileReader;
        public ProductFileImporter(IProductFileReader fileReader)
        {
            _FileReader = Startup.serviceProvider.BuildServiceProvider().GetService<IProductFileReader>(); ;
        }

        /*
         * Function to check file source is folder/url/ , then reads files according to source .
        */
        public void ImportFile(List<ProductImportConfiguration> productImportConfigurations)
        {
            //Iterate foreach import source defined in appsettings.json 
            foreach (ProductImportConfiguration importConfig in productImportConfigurations)
            {
                // checks if file source is folder or url
                if (!String.IsNullOrEmpty(importConfig.productsConfiguration.ProductFolderPath))
                {
                    if (CheckFolderExists(importConfig.productsConfiguration.ProductFolderPath))
                    {
                        //Iterate foreach file type defined in appsettings.json for folder
                        foreach (string file in importConfig.productsConfiguration.ProductFiles)
                        {
                            // Build file complete Path
                            var fileCompletePath = Path.Combine(importConfig.productsConfiguration.ProductFolderPath, file);
                            // Read file content from folder
                            _FileReader.ReadFilesFromFolder(fileCompletePath, file, importConfig.productsConfiguration.ImportOnDayOfWeek);
                        }
                    }
                    else
                        Console.WriteLine("Directory does not exist at {0} .\nFolder needs to be created at {0} and product source files needs to be placed in folder.", importConfig.productsConfiguration.ProductFolderPath);
                }
                // checks if file source is folder or url
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
