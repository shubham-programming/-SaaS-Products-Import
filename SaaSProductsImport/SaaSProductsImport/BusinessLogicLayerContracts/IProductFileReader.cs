using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSProductsImport.BusinessLogicLayer
{
    /*
     * -'IProductFileReader' interface builds contract with 'ProductFileReader' class for following actions/features -
     * -Includes methods for parsing file content from folder into a string.
     * -Passes content of file as string to 'IProductFileFormatParser'. 
    */
    public interface IProductFileReader 
    {
        //Function to read each file content from folder.
        public void ReadFilesFromFolder(string productfilePath , string productFileName, int importOnDayOfWeek);

        //Function to read each file content from url.
        public void ReadFilesFromURL(string productfilePath, string productFileName ,int importOnDayOfWeek);
    }
}
