using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSProductsImport.Model
{
    /* 
     * POCO Root Model class of Product Configuration mentioned in Appsettings.json file 
    */
   public class RootObject
    {
        public List<ProductImportConfiguration> ProductImportSource { get; set; }
    }
}
