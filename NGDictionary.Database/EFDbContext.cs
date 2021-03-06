﻿using Microsoft.EntityFrameworkCore;
using NGDictionary.Database.Entity;
using System;
using System.Reflection;

// https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli - Migrations
// https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet - EF Core tools reference - .NET CLI
namespace NGDictionary.Database
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Dictionary> Dictionaries { get; set; } = null!;

        public DbSet<Word> Words { get; set; } = null!;

        // https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key - Fluent API configuration
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
