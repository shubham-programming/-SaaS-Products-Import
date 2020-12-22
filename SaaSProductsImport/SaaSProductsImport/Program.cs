using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SaaSProductsImport.BusinessLogicLayer;
using SaaSProductsImport.Model;
using System;

namespace SaaSProductsImport
{
    class Program
    {
        static void Main(string[] args)
        { 
            Startup.Configure();
            // Assigns product sources from appsettings.json file into Configuration POCO model.
            var products = Startup.getProductImportSources();  
            ProductFileImporter fileImporter = new ProductFileImporter(Startup.serviceProvider.BuildServiceProvider().GetService<ProductFileReader>());
            fileImporter.ImportFile(products);
            Console.ReadLine();

        }
    }
}
