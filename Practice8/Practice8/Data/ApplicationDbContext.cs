using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Practice_8.Models;

namespace Practice_8.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Genre> Genres { get; set; }
    }
}
