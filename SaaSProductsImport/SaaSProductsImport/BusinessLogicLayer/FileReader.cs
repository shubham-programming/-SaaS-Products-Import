using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SaaSProductsImport.BusinessLogicLayer
{
    public class FileReader : IFileReader
    {
        IFileFormatParser _IProductParser;
        public FileReader(IFileFormatParser IProductParser)
        {
            _IProductParser = IProductParser;
        }
        public void ReadFilesFromFolder(ProductsConfiguration productImportSource)
        {
            //foreach(ProductFileModel productFile in  productImportSource.ProductFiles)
            //{
            //    productFile.FileContent = File.ReadAllText(productFile.FileCompletePath);

            //    switch (productFile.FileExtension)
            //    {
            //        case ".json" :
            //            _IProductParser.InsertYamlProducts(productFile);
            //            break;
            //        case ".csv" :
            //             _IProductParser.InsertCSVProducts(productFile);
            //            break;
            //        case ".yaml":
            //            _IProductParser.InsertYamlProducts(productFile);
            //            break;
            //    }

            //}

        }
        public void ReadFilesFromURL(ProductsConfiguration productImportSources)
        {
            /*
                *PlaceHolder for implementing product file read logic from URL 
                *This logic will store file data in ProductFile model's variable FileContent   
            */
        }
       
    }
}
