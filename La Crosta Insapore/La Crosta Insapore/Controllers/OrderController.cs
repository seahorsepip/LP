using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using La_Crosta_Insapore.Logic;
using La_Crosta_Insapore.Data;
using La_Crosta_Insapore.Models;

namespace La_Crosta_Insapore.Controllers
{
    public class OrderController : Controller
    {
        ProductRepository productRepository = new ProductRepository(new ProductSQLContext());

        public ActionResult Pizza()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("pizzas", productRepository.Get(ProductType.DEFAULT_PIZZA));
            data.Add("bottoms", productRepository.Get(ProductType.PIZZA_BOTTOM));
            data.Add("ingredients", productRepository.Get(ProductType.PIZZA_INGREDIENT));
            return View(data);
        }

        public ActionResult SideDish()
        {
            return View(productRepository.Get(ProductType.SIDE_DISH));
        }

        public ActionResult Drink()
        {
            return View(productRepository.Get(ProductType.DRINK));
        }
    }
}