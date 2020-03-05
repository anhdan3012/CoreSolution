using CoreSolution.Model.Configurations;
using CoreSolution.Model.Shop;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSolution.DBContext
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        public DbSet<Product> Products { set; get; }
    }
}
