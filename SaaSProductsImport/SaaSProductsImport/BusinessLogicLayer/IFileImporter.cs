using SaaSProductsImport.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSProductsImport.BusinessLogicLayer
{
    public interface IFileImporter
    {
        public void ImportFile();

        public bool CheckFolderExists(string path);
    }
}
