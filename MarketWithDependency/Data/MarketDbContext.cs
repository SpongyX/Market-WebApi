using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketWithDependency.Data
{
    public class MarketDbContext : DbContext
    { 
        public MarketDbContext(DbContextOptions<MarketDbContext> options)
         : base(options)
    {
    }
        public DbSet<Stuff> Stuffs { get; set; }
        public DbSet<StuffDetail> stuffDetails { get; set; }
}
}