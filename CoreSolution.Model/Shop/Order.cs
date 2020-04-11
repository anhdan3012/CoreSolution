using CoreSolution.Model.Enums;
using CoreSolution.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSolution.Model.Shop
{
    public class Order
    {
        public int Id { set; get; }
        public DateTime OrderDate { set; get; } 
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }
        public OrderStatus Status { set; get; }
        public Guid UserId { set; get; }

        public List<OrderDetail> OrderDetails { set; get; }
        public AppUser AppUser { set; get; }
    }
}
