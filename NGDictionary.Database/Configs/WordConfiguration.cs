using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NGDictionary.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGDictionary.Database.Configs
{
    public class WordConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.Property(x => x.Text).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Translation).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Details).IsRequired().HasMaxLength(512);
            builder.HasOne(x => x.Dictionary).WithMany(x => x.Words).HasForeignKey(x => x.DictionaryId);
        }
    }
}
