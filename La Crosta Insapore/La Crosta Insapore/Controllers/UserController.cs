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
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            UserModel user = new UserModel
            {
                Id = 5,
                Name = "Thomas",
                Role = UserRole.CUSTOMER
            };
            Session["User"] = user;
            Session["order"] = new OrderModel
            {
                Lines = new List<OrderLineModel>()
            };
            if(user.Role == UserRole.CUSTOMER)
            {
                return RedirectToAction("Pizza", "Order");
            }
            return RedirectToAction("Index", "Manage");
        }
    }
}