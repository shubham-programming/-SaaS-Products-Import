using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SaaSProductsImport.BusinessLogicLayer
{
    /*
     * 'ProductFileReader' class implements 'IProductFileReader' interface. This class perform following functions --
     *      a. Includes methods for parsing files content into string by reading the file data for each file - .csv, .json 
     *      b. Passes content of file as string to 'IProductFileFormatParser' for further execution.
    */
    public class ProductFileReader : IProductFileReader
    {
        IProductFileFormatParser _IProductParser;
        public ProductFileReader(IProductFileFormatParser IProductParser)
        {
            _IProductParser = IProductParser;
        }

        /*
        * a.Function to read file content  into a string if file source is folder.
        * b.Function accepts filePath , fileName , dayOfImportInWeek as arguments.
        * c.Passes file content as string to 'IProductFileFormatParser'.
       */
        public void ReadFilesFromFolder(string productFilePath, string productFileName, int importSchedule)
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
        /*
        * a.Function to read file content  into a string if file source is url.
        * b.Function accepts filePath , fileName , dayOfImportInWeek as arguments.
        * c.Passes file content as string to 'IProductFileFormatParser'.
       */
        public void ReadFilesFromURL(string productFilePath, string productFileName, int importSchedule)
        {
            /*
                *PlaceHolder for implementing product file read logic from URL 
                *This logic will store file data in ProductFile model's variable FileContent   
            */
        }

    }
}
