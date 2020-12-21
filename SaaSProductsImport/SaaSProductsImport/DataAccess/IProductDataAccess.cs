using System;
using System.Collections.Generic;
using System.Text;
using SaaSProductsImport.Model;

namespace SaaSProductsImport.DataAccess
{
    public interface IProductDataAccess
    {
        public void InsertProducts(FolderImporterModel products);
        
    }
}
