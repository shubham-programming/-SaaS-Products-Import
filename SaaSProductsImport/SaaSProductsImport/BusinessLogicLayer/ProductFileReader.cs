using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SaaSProductsImport.BusinessLogicLayer
{
    public class ProductFileReader : IProductFileReader
    {
        IProductFileFormatParser _IProductParser;
        public ProductFileReader(IProductFileFormatParser IProductParser)
        {
            _IProductParser = IProductParser;
        }
        public void ReadFilesFromFolder(string productFilePath ,string productFileName, int importSchedule)
        {
                string fileContent = File.ReadAllText(productFilePath);
                string productName = Path.GetFileNameWithoutExtension(productFileName);
                string productFileExtension = Path.GetExtension(productFileName);                
                switch (productFileExtension)
                {
                    case ".json":
                        _IProductParser.InsertJsonProducts(fileContent, productName);
                        break;
                    case ".csv":
                        _IProductParser.InsertCSVProducts(fileContent, productName);
                        break;
                    case ".yaml":
                        _IProductParser.InsertYamlProducts(fileContent, productName);
                        break;
                }

            

        }
        public void ReadFilesFromURL(string productFilePath, string productFileName, int importSchedule)
        {
            /*
                *PlaceHolder for implementing product file read logic from URL 
                *This logic will store file data in ProductFile model's variable FileContent   
            */
        }
       
    }
}
