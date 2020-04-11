﻿using CoreSolution.Model.Shop;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSolution.Model.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Dob { get; set; }

        public List<Cart> Carts { set; get; }
        public List<Order> Orders { set; get; }
        public List<Transaction> Transactions { set; get; }
    }
}
