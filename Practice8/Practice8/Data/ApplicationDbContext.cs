﻿using Microsoft.EntityFrameworkCore;
using Practice_8.Models;

namespace Practice_8.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Music> Musics { get; set; }

        //esec gpts daxmarebit 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasMany(g => g.Musics)
                .WithOne(m => m.Genre)
                .HasForeignKey(m => m.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
