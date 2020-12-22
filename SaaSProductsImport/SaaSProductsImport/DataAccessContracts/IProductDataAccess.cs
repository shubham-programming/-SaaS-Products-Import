using System;
using System.Collections.Generic;
using System.Text;
using SaaSProductsImport.Model;

namespace SaaSProductsImport.DataAccess
{

    /*
     * 'IProductDataAccess' interface binds contract with 'ProductDataAccess' class for following actions/features -
     *      a. Includes methods for inserting products POCO class object  into database.
    */
    public interface IProductDataAccess
    {
        public int InsertProducts(ProductsModel products);
        
    }
}
