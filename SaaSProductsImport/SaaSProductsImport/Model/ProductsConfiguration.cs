using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSProductsImport.Model
{
    public class ProductsConfiguration
    {
        public string ProductFolderPath { get; set; }
        public List<string> ProductFiles { get; set; }
        public int ImportOnDayOfWeek { get; set; }
        public string ProductDownloadUrl { get; set; }
    }

    public class ProductImportConfiguration
    {
        public ProductsConfiguration productsConfiguration { get; set; }
    }
}
