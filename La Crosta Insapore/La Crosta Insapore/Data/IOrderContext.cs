using La_Crosta_Insapore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace La_Crosta_Insapore.Data
{
    public interface IOrderContext
    {
        bool Submit(OrderModel order);
    }
}