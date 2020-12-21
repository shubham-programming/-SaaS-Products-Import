using Newtonsoft.Json;
using SaaSProductsImport.DataAccess;
using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSProductsImport.BusinessLogicLayer
{
    public class FileFormatParser : IFileFormatParser
    {
        IProductDataAccess _productDataAccess;

        public FileFormatParser(IProductDataAccess productDataAccess)
        {
            _productDataAccess = productDataAccess;
        }
        public int InsertJsonProducts(ProductFileModel productFile)
        {
            /*
             * This function accepts ProductFile model as parameter
             * This function performs following logic -
             *          1. Parse Json string to product
             * 
             */
            FolderImporterModel products = new FolderImporterModel();
            var productDetails = JsonConvert.DeserializeObject<ProductDetailsModel []>(productFile.FileContent);
            products.ProductName = productFile.FileName;
            products.ProductsDetails = productDetails;
            _productDataAccess.InsertProducts(products);
            return 0;
        }
        public int InsertCSVProducts(ProductFileModel productFile)
        {

            return 0;
        }
        public int InsertYamlProducts(ProductFileModel productFile)
        {
            return 0; 
        }

    }
}
