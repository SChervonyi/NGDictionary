using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NGDictionary.Database.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGDictionary.Database.Configs
{
    public class DictionaryConfiguration : IEntityTypeConfiguration<Dictionary>
    {
        public void Configure(EntityTypeBuilder<Dictionary> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Description).HasMaxLength(512);
            builder.Property(x => x.IsFavorite).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.ImageUrl).HasMaxLength(2083).HasColumnType("varchar(2083)");

            builder.HasMany(x => x.Words).WithOne();

            // https://entityframeworkcore.com/knowledge-base/49986756/efcore-map-2-entities-to-same-table
            // builder.HasOne<DictionaryMeta>().WithOne().HasForeignKey<Dictionary>(x => x.Id);
        }
    }
}
