﻿using CoreSolution.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSolution.Models.Shop
{
    public class Cart
    {
        public int Id { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public Guid UserId { set; get; }

        public Product Product { set; get; }
        public AppUser AppUser { set; get; }
    }
}
