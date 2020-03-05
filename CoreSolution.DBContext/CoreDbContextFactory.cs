using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoreSolution.DBContext
{
    public class CoreDbContextFactory : IDesignTimeDbContextFactory<CoreDbContext>
    {
        public CoreDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("CoreSolutionDb");

            var optionsBuilder = new DbContextOptionsBuilder<CoreDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new CoreDbContext(optionsBuilder.Options);
        }
    }
}
