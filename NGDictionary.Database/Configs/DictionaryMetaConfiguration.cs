﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NGDictionary.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGDictionary.Database.Configs
{
    public class DictionaryMetaConfiguration : IEntityTypeConfiguration<DictionaryMeta>
    {
        public void Configure(EntityTypeBuilder<DictionaryMeta> builder)
        {
            builder.ToTable("Dictionaries");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(256);
            builder.Property(x => x.Description).HasColumnName("Description").IsRequired().HasMaxLength(512); ;
            builder.Property(x => x.IsFavorite).HasColumnName("IsFavorite").IsRequired().HasDefaultValue(false);
            builder.Property(x => x.ImageUrl).HasColumnName("ImageUrl").IsRequired().HasMaxLength(2083).HasColumnType("varchar(2083)");
        }
    }
}
