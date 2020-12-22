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
        private string Name { get; set; }
        private string [] Categories { get; set; }
        private string  Twitter { get; set; }
    }   
    
}
