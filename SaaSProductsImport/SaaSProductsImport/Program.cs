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
            Startup startup = new Startup();
            startup.Configure();
            // Assigns product sources from appsettings.json file into Configuration POCO model.
            var products = startup.getProductImportSources();  
            ProductFileImporter fileImporter = new ProductFileImporter(startup.ServiceProvider.BuildServiceProvider().GetService<IProductFileReader>());
            fileImporter.ImportFile(products);
            Console.ReadLine();

        }
    }
}
