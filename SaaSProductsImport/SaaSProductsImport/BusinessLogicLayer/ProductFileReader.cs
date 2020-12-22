using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SaaSProductsImport.BusinessLogicLayer
{
    /*
     * 'ProductFileReader' class implements 'IProductFileReader' interface.--
     *  Includes functions for parsing files content into string by reading the file data for each fileextension {.csv,.json etc.} 
    */
    public class ProductFileReader : IProductFileReader
    {
        IProductFileFormatParser _IProductParser;
        public ProductFileReader(IProductFileFormatParser IProductParser)
        {
            _IProductParser = IProductParser;
        }

        /*
        * Function to read file content  into a string if file source is folder.
        * Accepts string: filePath ,string: fileName ,int: dayOfImportInWeek as arguments.
       */
        public void ReadFilesFromFolder(string productFilePath, string productFileName, int importSchedule)
        {            
            // Read all data of file into string
            string fileContent = File.ReadAllText(productFilePath);
            // set product name fetched from product file name
            string productName = Path.GetFileNameWithoutExtension(productFileName);
            // set product extension fetched from product file name
            string productFileExtension = Path.GetExtension(productFileName);
            //process file according to fileExtension

            Console.WriteLine("import {0} {1}", productName, productFilePath, productFileName);
            switch (productFileExtension)
            {
                case ".json":
                    // parse json object for database insert
                    _IProductParser.InsertJsonProducts(fileContent, productName);
                    break;
                case ".csv":
                    // parse csv object for database insert
                    _IProductParser.InsertCSVProducts(fileContent, productName);
                    break;
                case ".yaml":
                    // parse yaml object for database insert
                    _IProductParser.InsertYamlProducts(fileContent, productName);
                    break;
            }



        }
        /*
        * Function to read file content  into a string if file source is url.
        * Function accepts string: filePath ,string: fileName ,int: dayOfImportInWeek as arguments.
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
