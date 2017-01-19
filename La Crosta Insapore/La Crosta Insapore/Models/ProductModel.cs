using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace La_Crosta_Insapore.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PurchasePrice { get; set; }
        public int SalePrice { get; set; }
        public ProductType Type { get; set; }
    }
}