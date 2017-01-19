using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace La_Crosta_Insapore.Models
{
    public class PizzaModel : ProductModel
    {
        public Shape Shape { get; set; }
        public SizeModel Size { get; set; }
        public ProductModel Bottom { get; set; }
        public List<ProductModel> Ingredients { get; set; }
    }
}