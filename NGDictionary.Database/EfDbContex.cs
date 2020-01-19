using Microsoft.EntityFrameworkCore;
using NGDictionary.Dto;
using System;

namespace NGDictionary.Database
{
    public class EFDbContex : DbContext
    {
        public EFDbContex(DbContextOptions<EFDbContex> options)
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
