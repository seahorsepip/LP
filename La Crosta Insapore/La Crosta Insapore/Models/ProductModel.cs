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
        public decimal? PurchasePrice { get; set; }
        public decimal? SalePrice { get; set; }
        public ProductType Type { get; set; }
    }
}