using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace SaaSProductsImport
{
    /*
     * Configuration setting keys related to folder location , file extensions , ImportSchedule is binded with Configuration POCO Model class 
     * Binding should be done with IOptions , IServiceLocation interface which will reduced these line of code and will be better optimized code 
     * 
    */
    public class MapProductSourcesFromSettings
    {
        public void GetProductImportSources()
        {
            //    ProductImportSourceModel productImport = new ProductImportSourceModel();
            //    if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["ProductFolderPath"]))
            //    {
            //        productImport.IsFolderLocation = true;
            //        productImport.ProductImportPath = ConfigurationManager.AppSettings["ProductFolderPath"];
            //    }
            //    productImport.ImportOnDayOfWeek = Convert.ToInt32(ConfigurationManager.AppSettings["ImportOnDayOfWeek"]);
            //    if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["ProductFileExtension"]))
            //    {
            //        string[] files = ConfigurationManager.AppSettings["ProductFileExtension"].Split(",");
            //        ProductFileModel[] productFile = new ProductFileModel[files.Length];
            //        for (int i = 0; i < files.Length; i++)
            //        {
            //            var fileName = files[i];
            //            productFile[i] = new ProductFileModel();
            //            productFile[i].FileName = fileName;
            //            productFile[i].FileExtension = Path.GetExtension(fileName);
            //            productFile[i].FileCompletePath = Path.Combine(productImport.ProductImportPath, fileName);

            //        }
            //    }
            //    ProductImportModel products = new ProductImportModel();
            //    products.productImportSources.Add(productImport);
            //    return products;
            //}

        }
    }
}
