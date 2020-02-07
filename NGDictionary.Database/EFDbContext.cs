using Microsoft.EntityFrameworkCore;
using NGDictionary.Dto;
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

        public DbSet<DictionaryMeta> DictionariesMeta { get; set; } = null!;

        public DbSet<Word> Words { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
