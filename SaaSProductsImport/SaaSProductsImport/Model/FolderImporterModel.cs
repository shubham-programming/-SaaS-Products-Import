﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSProductsImport.Model
{
    public class FolderImporterModel
    {
        public string ProductName {get; set;}
        public ProductDetailsModel [] ProductsDetails { get; set; }
    }
}
