using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using La_Crosta_Insapore.Data;
using La_Crosta_Insapore.Models;

namespace La_Crosta_Insapore.Logic
{
    public class OrderRepository
    {
        IOrderContext context;

        public OrderRepository(IOrderContext context)
        {
            this.context = context;
        }

        public void Submit(OrderModel order)
        {
            if (!context.Submit(order))
            {
                throw new Exception();
            }
        }
    }
}