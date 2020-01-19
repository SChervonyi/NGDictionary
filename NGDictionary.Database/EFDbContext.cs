using Microsoft.EntityFrameworkCore;
using NGDictionary.Dto;
using System;

namespace NGDictionary.Database
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Dictionary> Dictionaries { get; set; }

        public DbSet<DictionaryMeta> DictionariesMeta { get; set; }

        public DbSet<Word> Words { get; set; }
    }
}
