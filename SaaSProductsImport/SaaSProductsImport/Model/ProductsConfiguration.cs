using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSProductsImport.Model
{
    /*
     * POCO Model class of Products Configuration - variable includes following
        * ProductFolderPath ,
        * ProductFiles , 
        * ImportOnDayOfWeek
        * ProductDownloadUrl
        * Values of POCO class fetched from appsettings.json file
    */
    public class ProductsConfiguration
    {
        public string ProductFolderPath { get; set; }
        public List<string> ProductFiles { get; set; }
        public int ImportOnDayOfWeek { get; set; }
        public string ProductDownloadUrl { get; set; }
    }

    /* 
     * POCO Model class of Products Configuration - variable includes ProductsConfiguration class 
    */
    public class ProductImportConfiguration
    {
        public ProductsConfiguration productsConfiguration { get; set; }
    }
}
