using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SaaSProductsImport.BusinessLogicLayer;
using SaaSProductsImport.DataAccess;
using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SaaSProductsImport
{
    public static class Startup
    {
        public static IConfigurationRoot Configuration;
        public static ServiceCollection serviceProvider = new ServiceCollection();        

        public static void AddInfrastructure()
        {
            serviceProvider.AddScoped<IProductDataAccess, ProductDataAccess>(i => new ProductDataAccess(BuildConnectionString()));
            serviceProvider.AddScoped<IFileFormatParser, FileFormatParser>(i => new FileFormatParser(i.GetService<IProductDataAccess>()));
            serviceProvider.AddScoped<IFileReader, FileReader>(i => new FileReader(i.GetService<IFileFormatParser>()));
            serviceProvider.AddScoped<IFileImporter, FileImporter>(i => new FileImporter(i.GetService<IFileReader>()));
           // serviceProvider.AddSingleton(Configuration.GetSection("ProductImportSources").Get<ProductsConfiguration>());
           // serviceProvider.Configure<ProductsSourceCollectionModel>(Configuration.GetSection("ProductImportSources"));
          //services.Configure<ProductSourceFolderModel>(options => Configuration.GetSection("MySettings").Bind(options));
          // return serviceProvider;
        }

        public static void Configure()
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder();                

              builder
                    .AddJsonFile(
                        Path.Combine(AppContext.BaseDirectory, string.Format("..{0}..{0}..{0}", Path.DirectorySeparatorChar), $"appsettings.json"),
                        optional: true
                    );
            Configuration = builder.Build();           
            AddInfrastructure();
           
        }

        private static string BuildConnectionString()
        {
            string connectionString = Configuration.GetConnectionString("DatabaseConnection");
            if (connectionString == null)
            {
                throw new InvalidOperationException("Missing connection string: " + connectionString);
            }
            return connectionString;
        }

        public static List<ProductImportConfiguration> getProductImportSources()
        {
            List< ProductImportConfiguration> productImportConfiguration = new List<ProductImportConfiguration>();
            Configuration.GetSection("ProductImportConfiguration").Bind(productImportConfiguration);
            return productImportConfiguration;
        }      
    }
}
