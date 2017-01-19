using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using La_Crosta_Insapore.Models;
using System.Data.SqlClient;
using System.Configuration;

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
            Dictionary<int, ProductModel> products = new Dictionary<int, ProductModel>();
            string query = @"EXEC [dbo].GetProducts @Type;";
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Type", (int)type);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        if (type == ProductType.DEFAULT_PIZZA || type == ProductType.CUSTOM_PIZZA)
                        {
                            PizzaModel pizza;

                            if (products.ContainsKey(id))
                            {
                                pizza = (PizzaModel)products[id];
                            }
                            else
                            {
                                pizza = new PizzaModel
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Ingredients = new List<ProductModel>(),
                                    Shape = (Shape)reader.GetInt32(4),
                                    Size = new SizeModel
                                    {
                                        X = reader.GetInt32(5),
                                        Y = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6),
                                        Z = reader.IsDBNull(7) ? (int?)null : reader.GetInt32(7)
                                    }
                                };
                            }

                            //Ingredients logic
                            if (!reader.IsDBNull(8))
                            {
                                ProductModel ingredient = new ProductModel
                                {
                                    Id = reader.GetInt32(8),
                                    Name = reader.GetString(9),
                                    PurchasePrice = reader.IsDBNull(11) ? (decimal?)null : reader.GetDecimal(11),
                                    SalePrice = reader.IsDBNull(12) ? (decimal?)null : reader.GetDecimal(12)
                                };
                                if ((ProductType)reader.GetInt32(10) == ProductType.PIZZA_BOTTOM)
                                {
                                    pizza.Bottom = ingredient;
                                }
                                else
                                {
                                    pizza.Ingredients.Add(ingredient);
                                }
                            }
                            products[id] = pizza;
                        }
                        else
                        {
                            products.Add(id, new ProductModel
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                PurchasePrice = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                SalePrice = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3),
                            });
                        }
                    }
                }
            }
            return products.Values.ToList();
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