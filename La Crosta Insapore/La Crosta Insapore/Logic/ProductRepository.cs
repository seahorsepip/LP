using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using La_Crosta_Insapore.Data;
using La_Crosta_Insapore.Models;

namespace La_Crosta_Insapore.Logic
{
    public class ProductRepository
    {
        IProductContext context;

        public ProductRepository(IProductContext context)
        {
            this.context = context;
        }

        public ProductModel Add(ProductModel product)
        {
            product.Id =  context.Add(product);
            if (product.Id == 0)
            {
                throw new Exception();
            }
            return product;
        }

        public List<ProductModel> Get(ProductType type)
        {
            return context.Get(type);
        }

        public void Update(ProductModel product)
        {
            if (!context.Update(product))
            {
                throw new Exception();
            }
        }

        public void Remove(int id)
        {
            if (!context.Remove(id))
            {
                throw new Exception();
            }
        }
    }
}