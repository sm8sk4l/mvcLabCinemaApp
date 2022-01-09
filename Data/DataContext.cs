using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;

using Microsoft.EntityFrameworkCore;
using KinoProject.Models;

namespace KinoProject.Data;

public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ProjectDatabase.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         modelBuilder.Entity<User>()
        .HasMany(t => t.Tickets)
        .WithOne(u => u.User);

       modelBuilder.Entity<Movie>()
        .HasMany(m => m.Tickets)
        .WithOne(t => t.Movie);

        modelBuilder.Entity<Movie>()
        .HasMany(m => m.Halls)
        .WithOne(h => h.Movie);

         modelBuilder.Entity<Cinema>()
        .HasMany(m => m.Halls)
        .WithOne(h => h.Cinema);

        

    }
    public DbSet<User> Users { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Hall> Halls { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }


}
