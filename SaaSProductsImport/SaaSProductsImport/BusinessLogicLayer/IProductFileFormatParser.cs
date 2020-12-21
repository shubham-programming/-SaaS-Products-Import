using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSProductsImport.BusinessLogicLayer
{
    public interface IProductFileFormatParser
    {
        public int InsertJsonProducts(string productDetails,string productName);
        public int InsertCSVProducts(string productDetails, string productName);
        public int InsertYamlProducts(string productDetails, string productName);
    }
}
