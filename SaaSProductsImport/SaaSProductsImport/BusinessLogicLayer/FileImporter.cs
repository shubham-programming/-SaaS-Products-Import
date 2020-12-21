using Microsoft.Extensions.Options;
using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SaaSProductsImport.BusinessLogicLayer
{
    public class FileImporter : IFileImporter
    {
        private IFileReader _FileReader;
        private readonly ProductsConfiguration _productImportSources;
        public FileImporter(IFileReader fileReader )
        {            
            _FileReader = fileReader;
        }        

        public void ImportFile()
        {
            //var products = 
            //foreach(ProductImportSource importSource in null )
            //{
            //    if(importSource.IsFolderLocation)
            //    {                    
            //        _FileReader.ReadFilesFromFolder(importSource);                   
            //    }
            //    else if(importSource.IsUrlLocation)
            //    {
            //        _FileReader.ReadFilesFromURL(importSource);
            //    }
            //}
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
