using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Suduko.Model.Entities;

namespace Suduko.Infrastructure.Data
{
    internal class MyDBContext : DbContext
    {
        string build_loc = ""; // Will be empty on git
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(build_loc);
        }

        public DbSet<SudukoLayout> SudukoLayout { get; set; } = default;
    }
}
