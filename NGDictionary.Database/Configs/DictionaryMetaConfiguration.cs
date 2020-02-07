using Microsoft.EntityFrameworkCore;
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
            throw new NotImplementedException();
        }
    }
}
