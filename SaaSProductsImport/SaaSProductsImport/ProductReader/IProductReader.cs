using System;
using System.Collections.Generic;
using System.Text;
using SaaSProductsImport.ProductModel;

namespace SaaSProductsImport.ProductReader
{
   public interface IProductReader
    {
        public void  ReadCSVFile(string FilePath);
        public void ReadYamlFile(string FilePath);
        public void ReadJsonFile(string FilePath);
    }
}
