using PieShop.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PieShop.Data
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
