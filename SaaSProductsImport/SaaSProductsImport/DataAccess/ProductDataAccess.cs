using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSProductsImport.DataAccess
{
     public class ProductDataAccess : IProductDataAccess
    {
        private readonly string _connectionString;
        public ProductDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void InsertProducts(FolderImporterModel products)
        {
            /*
                Add logic for executing Database inserts 
            */
        }
    }
}
