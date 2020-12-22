using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSProductsImport.DataAccess
{
    /*
    * 'ProductDataAccess' class implements contract with 'IProductDataAccess' class for following actions/features -
    *      a. Includes methods for inserting products POCO class object  into database.
   */
    public class ProductDataAccess : IProductDataAccess
    {
        // connectionString set through Dependency Injection - connectionString value configurable in appsettings.json
        private readonly string _connectionString;
        public ProductDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }
        public int InsertProducts(ProductsModel products)
        {
            /*
                Add logic for executing Database insert operation
            */
            return 0;
        }
    }
}
