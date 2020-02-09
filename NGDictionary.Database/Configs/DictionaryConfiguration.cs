using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NGDictionary.Dto;
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
            builder.Property(x => x.Description).IsRequired().HasMaxLength(515);
            builder.Property(x => x.IsFavorite).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(2083).HasColumnType("varchar(2083)");

            builder.HasMany(x => x.Words).WithOne();


            builder.HasOne<DictionaryMeta>().WithOne().HasForeignKey<Dictionary>(x => x.Id);
        }
    }
}
