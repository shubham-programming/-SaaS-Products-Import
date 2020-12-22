using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSProductsImport.Model
{
    /*
     * POCO Model class of Product details - variable includes Name , Array of Catepories , Twitter
    */
    public class ProductDetailsModel
    {
        public string Name { get; set; }
        public string  Categories { get; set; }
        public string  Twitter { get; set; }
    }   
    
}
