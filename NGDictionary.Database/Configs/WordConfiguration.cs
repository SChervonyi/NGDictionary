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
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Text).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Translation).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Details).HasMaxLength(512);
            builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(2083).HasColumnType("varchar(2083)");
            builder.Property(x => x.AudioUrl).IsRequired().HasMaxLength(2083).HasColumnType("varchar(2083)");

            // https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key
            builder.HasOne(x => x.Dictionary).WithMany(x => x.Words).HasForeignKey(x => x.DictionaryId);
        }
    }
}
