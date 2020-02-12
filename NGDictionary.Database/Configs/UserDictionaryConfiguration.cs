using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NGDictionary.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGDictionary.Database.Configs
{
    public class UserDictionaryConfiguration : IEntityTypeConfiguration<UserDictionary>
    {
        public void Configure(EntityTypeBuilder<UserDictionary> builder)
        {
            builder.HasKey(x => new { x.UserId, x.DictionaryId });

            // Unnecessary configuration, could be resolved by EF convention
            builder.HasOne(ud => ud.User)
                .WithMany(u => u.UserDictionaries)
                .HasForeignKey(ud => ud.UserId);

            // Unnecessary configuration, could be resolved by EF convention
            builder.HasOne(sc => sc.Dictionary)
                .WithMany(s => s.UserDictionaries)
                .HasForeignKey(sc => sc.DictionaryId);
        }
    }
}
