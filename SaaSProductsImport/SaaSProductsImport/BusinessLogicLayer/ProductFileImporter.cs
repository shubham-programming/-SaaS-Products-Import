using Microsoft.Extensions.Options;
using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SaaSProductsImport.BusinessLogicLayer
{
    public class ProductFileImporter : IProductImporter
    {
        private IProductFileReader _FileReader;
        private readonly ProductsConfiguration _productImportSources;
        public ProductFileImporter(IProductFileReader fileReader )
        {            
            _FileReader = fileReader;
        }        

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
