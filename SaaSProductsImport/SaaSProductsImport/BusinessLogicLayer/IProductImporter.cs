using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSProductsImport.BusinessLogicLayer
{
    public interface IProductImporter
    {
        public void ImportFile(List<ProductImportConfiguration> productImportConfigurations);

        public bool CheckFolderExists(string path);
    }
}
