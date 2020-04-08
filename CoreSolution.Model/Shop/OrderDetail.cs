using CoreSolution.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSolution.Model.Shop
{
    public class OrderDetail
    {
        public int OrderId { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
