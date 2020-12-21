using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSProductsImport.BusinessLogicLayer
{
    public interface IFileFormatParser
    {
        public int InsertJsonProducts(ProductFileModel productFile);
        public int InsertCSVProducts(ProductFileModel productFile);
        public int InsertYamlProducts(ProductFileModel productFile);
    }
}
