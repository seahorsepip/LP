using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using La_Crosta_Insapore.Models;

namespace La_Crosta_Insapore.Data
{
    public class ProductSQLContext : IProductContext
    {
        public int Add(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> Get(ProductType type)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}