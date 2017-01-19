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

        public new decimal PurchasePrice
        {
            get
            {
                decimal price = Bottom.PurchasePrice.Value;
                foreach (ProductModel ingredient in Ingredients)
                {
                    price += ingredient.PurchasePrice.Value;
                }
                return price;
            }
        }

        public new decimal SalePrice
        {
            get
            {
                decimal price = Bottom.SalePrice.Value;
                foreach(ProductModel ingredient in Ingredients)
                {
                    price += ingredient.SalePrice.Value;
                }
                return price;
            }
        }

        public decimal Surface
        {
            get
            {
                switch (Shape)
                {
                    default:
                    case Shape.ROUND:
                        return ((decimal)0.25 * (decimal)Math.PI * Size.X * Size.X);
                    case Shape.RECTANGULAR:
                        return Size.X * Size.Y.Value;
                    case Shape.TRIANGLE:
                        decimal s = (Size.X + Size.Y.Value + Size.Z.Value) / 2;
                        return (decimal)Math.Sqrt((double)(s * (s - Size.X) * (s - Size.Y.Value) * (s - Size.Z.Value)));
                }
            }
        }
    }
}