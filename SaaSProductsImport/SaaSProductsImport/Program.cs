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
            Console.WriteLine("Hello World!");
            Startup.Configure();
            Startup.getProductImportSources();
            //var products = Startup.GetProductImportSources();
            FileImporter fileImporter = new FileImporter(Startup.serviceProvider.BuildServiceProvider().GetService<FileReader>());
            fileImporter.ImportFile();
            Console.ReadLine();

        }
    }
}
