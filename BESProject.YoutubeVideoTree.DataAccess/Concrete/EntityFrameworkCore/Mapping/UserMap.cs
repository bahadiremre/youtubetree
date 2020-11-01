using BESProject.YoutubeVideoTree.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BESProject.YoutubeVideoTree.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Set Id prop as PK
            builder.HasKey(u => u.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(50);
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(20).IsRequired();
        }
    }
}
