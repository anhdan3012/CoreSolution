﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSolution.Models.Shop
{
    public class ProductInCategory
    {
        public int ProductId { set; get; }
        public Product Product { set; get; }
        public int CategoryId { set; get; }
        public Category Category { set; get; }
    }
}
