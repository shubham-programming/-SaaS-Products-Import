using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSProductsImport.Model
{
    /* 
     * POCO Model class of Products  - variable includes ProductName ,Array of Product Details 
     * Product details are inserted in database through this model
    */
    public class ProductsModel
    {
        public string ProductName {get; set;}
        public ProductDetailsModel [] ProductsDetails { get; set; }
    }
}
