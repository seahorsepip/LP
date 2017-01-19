using La_Crosta_Insapore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace La_Crosta_Insapore.Data
{
    public interface IProductContext
    {
        int Add(ProductModel product);
        List<ProductModel> Get(ProductType type);
        bool Update(ProductModel product);
        bool Remove(int id);
    }
}