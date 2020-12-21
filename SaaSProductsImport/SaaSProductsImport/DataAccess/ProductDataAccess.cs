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
        public int InsertProducts(ProductsModel products)
        {
            /*
                Add logic for executing Database inserts 
            */
            return 0;
        }
    }
}
