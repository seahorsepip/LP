using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace La_Crosta_Insapore.Models
{
    public class OrderLineModel
    {
        public int Quantity { get; set; }
        public ProductModel product { get; set; }
    }
}