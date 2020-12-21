using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSProductsImport.BusinessLogicLayer
{
    public interface IFileReader 
    {
        public void ReadFilesFromFolder(ProductsConfiguration productImportSources);

        public void ReadFilesFromURL(ProductsConfiguration productImportSources);
    }
}
