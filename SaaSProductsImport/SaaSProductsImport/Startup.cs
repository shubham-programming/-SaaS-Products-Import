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
    /*
      * 'Startup' is static class that adds configuration , services as per scope for the execution of entire application logic. 
    */
    public class Startup
    {
        private  IConfigurationRoot Configuration;
        public  ServiceCollection ServiceProvider = new ServiceCollection();

        // Function to add services as perscope defined.        
        private void AddInfrastructure()
        {
            //Add scope for dependency injection
            ServiceProvider.AddScoped<IProductDataAccess, ProductDataAccess>(i => new ProductDataAccess(BuildConnectionString()));
            ServiceProvider.AddScoped<IProductFileFormatParser, ProductFileFormatParser>(i => new ProductFileFormatParser(i.GetService<IProductDataAccess>()));
            ServiceProvider.AddScoped<IProductFileReader, ProductFileReader>(i => new ProductFileReader(i.GetService<IProductFileFormatParser>()));
            ServiceProvider.AddScoped<IProductImporter, ProductFileImporter>(i => new ProductFileImporter(i.GetService<IProductFileReader>()));
        }

        // Function to cofigure configuration values through appsettings.json.      
        public void Configure()
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder();
            //Add appsettings.json file
            builder
                  .AddJsonFile(
                      Path.Combine(AppContext.BaseDirectory, string.Format("..{0}..{0}..{0}", Path.DirectorySeparatorChar), $"appsettings.json"),
                      optional: true
                  );
            Configuration = builder.Build();
            AddInfrastructure();

        }

        // Function to fetch connectionString values from appsettings.json.      
        private string BuildConnectionString()
        {
            string connectionString = Configuration.GetConnectionString("DatabaseConnection");
            if (connectionString == null)
            {
                throw new InvalidOperationException("Missing connection string: " + connectionString);
            }
            return connectionString;
        }

        // Function to assign POCO Model from product source configuration values in appsettings.json file.  
        public IList<ProductImportConfiguration> getProductImportSources()
        {
            IList<ProductImportConfiguration> productImportConfiguration = new List<ProductImportConfiguration>();
            Configuration.GetSection("ProductImportConfiguration").Bind(productImportConfiguration);
            return productImportConfiguration;
        }
    }
}
