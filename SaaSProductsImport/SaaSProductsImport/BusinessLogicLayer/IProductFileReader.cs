using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSProductsImport.BusinessLogicLayer
{
    public interface IProductFileReader 
    {
        public void ReadFilesFromFolder(string productfilePath , string productFileName, int importOnDayOfWeek);

        public void ReadFilesFromURL(string productfilePath, string productFileName ,int importOnDayOfWeek);
    }
}
