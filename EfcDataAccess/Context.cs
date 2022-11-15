﻿using Domain;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;

public class Context : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/Post.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>().HasKey(post => post.PostId);
        modelBuilder.Entity<User>().HasKey(user => user.Username);
    }
}