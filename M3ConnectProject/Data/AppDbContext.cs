using Microsoft.EntityFrameworkCore;
using M3ConnectProject.Models;
using System.Collections.Generic;

namespace M3ConnectProject.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        
    }
}
