using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebProject.Models;

namespace SalesWebProject.Data
{
    public class SalesWebProjectContext : DbContext
    {
        public SalesWebProjectContext (DbContextOptions<SalesWebProjectContext> options)
            : base(options)
        {
        }

        public DbSet<SalesWebProject.Models.Department> Department { get; set; }
        public DbSet<SalesWebProject.Models.Seller> Seller { get; set; }
        public DbSet<SalesWebProject.Models.SalesRecord> SalesRecord { get; set; }
        
    }
}
