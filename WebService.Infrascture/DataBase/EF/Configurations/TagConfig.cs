using WebService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Infrascture.DataBase.EF.Configurations
{
    public class TagConfig : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(c => c.ID);
            builder.Property(c => c.Name).HasMaxLength(30).IsRequired();
            builder.Property(c => c.Product_ID).IsRequired();
        }
    }
}
